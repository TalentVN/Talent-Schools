using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Entities;

namespace TSM.Data.Application
{
    public class TSMContextSeed
    {
        public static async Task SeedAsync(TSMContext context)
        {
            try
            {
                if (!context.Schools.Any())
                {


                    // Init EducationPrograms
                    List<EducationProgram> programs = new List<EducationProgram>
                        {
                            new EducationProgram()
                            {
                                Name = "Program 1",
                            },
                            new EducationProgram()
                            {
                                Name = "Program 2",
                            },
                            new EducationProgram()
                            {
                                Name = "Program 3",
                            }
                        };

                    await context.EducationPrograms.AddRangeAsync(programs);


                    // Init Majors
                    List<Major> majors = new List<Major>
                        {
                            new Major()
                            {
                                Name = "Major 1",
                            },
                            new Major()
                            {
                                Name = "Major 2",
                            },
                            new Major()
                            {
                                Name = "Major 3",
                            }
                        };

                    await context.Majors.AddRangeAsync(majors);


                    // Init Schools
                    List<School> schools = new List<School> {
                        new School()
                        {
                            Name = "School 1",
                        },
                        new School()
                        {
                            Name = "School 2"
                        },
                        new School()
                        {
                            Name = "School 3"
                        },
                    };

                    await context.Schools.AddRangeAsync(schools);

                    IEnumerable<Rating> ratings = new List<Rating>
                    {
                        new Rating(schools[0].Id, Guid.NewGuid(), Common.Enums.RatingType.ForSchool, "No comment", 3),
                        new Rating(schools[1].Id,Guid.NewGuid(), Common.Enums.RatingType.ForSchool, "No comment", 3),
                        new Rating(schools[2].Id,Guid.NewGuid(), Common.Enums.RatingType.ForSchool, "No comment", 3),
                    };

                    await context.Ratings.AddRangeAsync(ratings);

                    IEnumerable<SchoolMajor> schoolMajors = new List<SchoolMajor> {
                        new SchoolMajor()
                        {
                            SchoolId = schools[0].Id,
                            MajorId = majors[0].Id
                        },
                        new SchoolMajor()
                        {
                            SchoolId = schools[1].Id,
                            MajorId = majors[1].Id
                        },
                        new SchoolMajor()
                        {
                            SchoolId = schools[2].Id,
                            MajorId = majors[2].Id
                        }
                    };

                    await context.SchoolMajors.AddRangeAsync(schoolMajors);

                    IEnumerable<SchoolEducationProgram> schoolEducationPrograms = new List<SchoolEducationProgram> {
                        new SchoolEducationProgram()
                        {
                            SchoolId = schools[0].Id,
                            EducationProgramId = programs[0].Id
                        },
                        new SchoolEducationProgram()
                        {
                            SchoolId = schools[1].Id,
                            EducationProgramId = programs[1].Id
                        },
                        new SchoolEducationProgram()
                        {
                            SchoolId = schools[2].Id,
                            EducationProgramId = programs[2].Id
                        }
                    };

                    await context.SchoolEducationPrograms.AddRangeAsync(schoolEducationPrograms);

                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
