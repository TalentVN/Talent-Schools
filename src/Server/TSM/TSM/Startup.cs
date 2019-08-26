using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TSM.Extensions;
using AutoMapper;
using TSM.Common;
using Swashbuckle.AspNetCore.Swagger;
using TSM.Data.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TSM.Data.Entities;
using TSM.Data.Identity;
using TSM.Logging;
using TSM.Settings;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using TSM.Interfaces;
using TSM.Services;
using System.Security.Claims;

namespace TSM
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // add-migration InitAppData -context TSM.Data.Application.TSMContext -o Data/Application/Migrations
            // update-database -context TSM.Data.Application.TSMContext
            services.AddDbContext<TSMContext>(options =>
                                       options.UseSqlServer(Configuration.GetConnectionString("TSMConnection")));

            // add-migration InitIdentity -context TSM.Data.Identity.AppIdentityContext -o Data/Identity/Migrations
            // update-database -context TSM.Data.Identity.AppIdentityContext
            services.AddDbContext<AppIdentityContext>(options =>
                                       options.UseSqlServer(Configuration.GetConnectionString("TSMConnection")));

            CreateIdentityIfNotCreated(services);

            //DIs
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<IEmailService, EmailService>();

            services.AddScoped<IEducationProgramService, EducationProgramService>();

            services.AddScoped<ISchoolEducationProgramService, SchoolEducationProgramService>();
            services.AddScoped<ISchoolMajorService, SchoolMajorService>();
            services.AddScoped<ISchoolService, SchoolService>();

            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IUserService, UserService>();

            // Settings
            services.Configure<EmailSetting>(options => Configuration.GetSection("EmailSetting").Bind(options));

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSettingsSection);

            // configure jwt authentication
            var appSetting = appSettingsSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSetting.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy("Admin", policy => 
                    policy.RequireAssertion(context =>
                        context.User.FindFirst(ClaimTypes.Role)?.Value == "Admin"));

                x.AddPolicy("Orginaztion", policy =>
                    policy.RequireAssertion(context =>
                        context.User.FindFirst(ClaimTypes.Role)?.Value == "Orginaztion"));
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            IdentityModelEventSource.ShowPII = true;

            // Add AutoMapper
            services.AddAutoMapper();

            services.AddCors();

            services.AddMvcCore(options =>
            {
                options.Filters.Add(typeof(ValidateModelFilter));
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        private static void CreateIdentityIfNotCreated(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            {
                var existingUserManager = scope.ServiceProvider
                    .GetService<UserManager<ApplicationUser>>();
                if (existingUserManager == null)
                {
                    services.AddIdentity<ApplicationUser, IdentityRole>(
                        config =>
                        {
                            config.SignIn.RequireConfirmedEmail = false;
                        })
                        .AddEntityFrameworkStores<AppIdentityContext>()
                                        .AddDefaultTokenProviders();
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<ApplicationUser> userManager, TSMContext context)
        {
            _ = AppIdentityContextSeed.SeedAsync(userManager);
            _ = TSMContextSeed.SeedAsync(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
