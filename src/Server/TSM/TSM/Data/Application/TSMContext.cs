using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Entities;

namespace TSM.Data.Application
{
    public class TSMContext : DbContext
    {
        public TSMContext(DbContextOptions<TSMContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SchoolEducationProgram>().HasKey(sp => new { sp.SchoolId, sp.EducationProgramId });
            builder.Entity<SchoolMajor>().HasKey(sp => new { sp.SchoolId, sp.MajorId });
        }

        public DbSet<School> Schools { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<EducationProgram> EducationPrograms { get; set; }
        public DbSet<SchoolEducationProgram> SchoolEducationPrograms { get; set; }

        public DbSet<Major> Majors { get; set; }
        public DbSet<SchoolMajor> SchoolMajors { get; set; }

        public DbSet<Rating> Ratings { get; set; }
    }
}
