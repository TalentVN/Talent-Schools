using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models;
using TSM.Models.ResponseModels;

namespace TSM.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IAppLogger<UserService> _logger;

        public UserService(
            UserManager<ApplicationUser> userManager,
            IMapper mapper, 
            IEmailService emailService,
            IAppLogger<UserService> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<UserAdminModel> GetUsers()
        {
            var users = _userManager.Users.ToList();
            var results = _mapper.Map<IEnumerable<UserAdminModel>>(users);

            return results;
        }

        public async Task<UserAdminModel> GetUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = _mapper.Map<UserAdminModel>(user);

            return result;
        }

        public async Task<IdentityResult> CreateUser(UserAdminModel requestModel)
        {
            var user = new ApplicationUser
            {
                Email = requestModel.Email,
                UserName = requestModel.Email,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Address = requestModel.Address,
                JwtRole = requestModel.Role
            };

            var result = await _userManager.CreateAsync(user, requestModel.PassWord);

            if (result.Succeeded)
            {
                string confirmationToken =  await _userManager.GenerateEmailConfirmationTokenAsync(user);

                string confirmUrl = $"https://{5001}" + "emailconfirmation?userid={0}&code={1}";

                string callbackUrl = string.Format(confirmUrl, user.Id, confirmationToken);

                await _emailService.SendEmailAsync(requestModel.Email, "Confirm Email", callbackUrl);
            }

            return result;
        }

        public Task UpdateUser(UserAdminModel requestModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> DeleteUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.DeleteAsync(user);
        }
    }
}
