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
                            Code = "S1",
                            Description = @"Với bề dày thành tích 56 năm (05/10/1962 –05/10/2018), từ khi thành lập đến nay, Trường ĐH SPKT TPHCM đã đào tạo và bồi dưỡng nguồn nhân lực cho hệ thống giáo dục nghề nghiệp cũng như cung cấp đội ngũ kỹ sư chất lượng cao cho cả
                            nước, đặc biệt là góp sức to lớn vào thành tựu kinh tế xã hội của cả nước.",
                            SchoolType = Common.Enums.SchoolType.PUBLIC,
                            TuiTion = 5000,
                            StudentCount = 2000,
                            Website = "https://google.com",
                            CoverUrl = "http://covermyfb.com/media/covers/fBGeYvzQ4H5Yu1JI.jpg",
                            Specialty = Common.Enums.Specialty.Technology
                        },
                        new School()
                        {
                            Name = "School 2",
                            Code = "S2",
                            Description = @"Với bề dày thành tích 56 năm (05/10/1962 –05/10/2018), từ khi thành lập đến nay, Trường ĐH SPKT TPHCM đã đào tạo và bồi dưỡng nguồn nhân lực cho hệ thống giáo dục nghề nghiệp cũng như cung cấp đội ngũ kỹ sư chất lượng cao cho cả
                            nước, đặc biệt là góp sức to lớn vào thành tựu kinh tế xã hội của cả nước.",
                            SchoolType = Common.Enums.SchoolType.PUBLIC,
                            TuiTion = 5000,
                            StudentCount = 2000,
                            Website = "https://google.com",
                            CoverUrl = "http://covermyfb.com/media/covers/fBGeYvzQ4H5Yu1JI.jpg",
                            Specialty = Common.Enums.Specialty.Technology
                        },
                        new School()
                        {
                            Name = "School 3",
                            Code = "S3",
                            Description = @"Với bề dày thành tích 56 năm (05/10/1962 –05/10/2018), từ khi thành lập đến nay, Trường ĐH SPKT TPHCM đã đào tạo và bồi dưỡng nguồn nhân lực cho hệ thống giáo dục nghề nghiệp cũng như cung cấp đội ngũ kỹ sư chất lượng cao cho cả
                            nước, đặc biệt là góp sức to lớn vào thành tựu kinh tế xã hội của cả nước.",
                            SchoolType = Common.Enums.SchoolType.PUBLIC,
                            TuiTion = 5000,
                            StudentCount = 2000,
                            Website = "https://google.com",
                            CoverUrl = "http://covermyfb.com/media/covers/fBGeYvzQ4H5Yu1JI.jpg",
                            Specialty = Common.Enums.Specialty.Technology
                        },
                    };

                    await context.Schools.AddRangeAsync(schools);

                    //IEnumerable<Rating> ratings = new List<Rating>
                    //{
                    //    new Rating(schools[0].Id, Guid.NewGuid(), Common.Enums.RatingType.ForSchool, "No comment", 3),
                    //    new Rating(schools[1].Id,Guid.NewGuid(), Common.Enums.RatingType.ForSchool, "No comment", 3),
                    //    new Rating(schools[2].Id,Guid.NewGuid(), Common.Enums.RatingType.ForSchool, "No comment", 3),
                    //};

                    //await context.Ratings.AddRangeAsync(ratings);

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

                    IList<City> citites = new List<City>
                    {
                        new City()
                        {
                             Code = "1",
                             Name = "City 1"
                        },
                        new City()
                        {
                             Code = "2",
                             Name = "City 2"
                        },
                        new City()
                        {
                             Code = "3",
                             Name = "City 3"
                        }
                    };

                    await context.Cities.AddRangeAsync(citites);

                    IList<Country> countries = new List<Country>
                    {
                        new Country()
                        {
                             Code = "1",
                             Name = "Country 1"
                        },
                        new Country()
                        {
                             Code = "2",
                             Name = "Country 2"
                        },
                        new Country()
                        {
                             Code = "3",
                             Name = "Country 3"
                        }
                    };

                    await context.Countries.AddRangeAsync(countries);

                    IEnumerable<Location> locations = new List<Location>
                    {
                        new Location()
                        {
                             CityId = citites[0].Id,
                             CountryId = countries[0].Id,
                             SchoolId = schools[0].Id
                        },
                        new Location()
                        {
                             CityId = citites[1].Id,
                             CountryId = countries[1].Id,
                             SchoolId = schools[1].Id
                        },
                        new Location()
                        {
                             CityId = citites[2].Id,
                             CountryId = countries[2].Id,
                             SchoolId = schools[2].Id
                        },
                    };

                    await context.Locations.AddRangeAsync(locations);

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
