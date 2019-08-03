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
        public DbSet<School> Schools { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<EducationProgram> EducationPrograms { get; set; }
        public DbSet<SchoolEducationProgram> SchoolEducationPrograms { get; set; }

        public DbSet<Major> Majors { get; set; }
        public DbSet<SchoolMajor> SchoolMajors { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<ProgramScore> ProgramScores { get; set; }
        public DbSet<MajorScore> MajorScores { get; set; }

        public TSMContext(DbContextOptions<TSMContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            BuildHasKeys(builder);

            BuildHasIndexs(builder);

            BuildHasColumnTypes(builder);
        }

        private void BuildHasIndexs(ModelBuilder builder)
        {

        }

        private void BuildHasColumnTypes(ModelBuilder builder)
        {
            builder.Entity<ProgramScore>()
                            .Property(p => p.Value)
                            .HasColumnType("decimal(18,2)");


            builder.Entity<MajorScore>()
                           .Property(p => p.Value)
                           .HasColumnType("decimal(18,2)");
        }

        private void BuildHasKeys(ModelBuilder builder)
        {
            builder.Entity<SchoolEducationProgram>().HasKey(sp => new { sp.SchoolId, sp.EducationProgramId });
            builder.Entity<SchoolMajor>().HasKey(sp => new { sp.SchoolId, sp.MajorId });
        }
    }
}
