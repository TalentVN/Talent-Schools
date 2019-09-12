using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common;
using TSM.Data.Application;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Models;
using TSM.Models.RequestModels;
using TSM.Models.ResponseModels;

namespace TSM.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IMapper _mapper;
        private readonly TSMContext _context;

        public SchoolService(
            IMapper mapper,
            TSMContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PagingModel<SchoolResponseModel>> GetPagingSchools(int currentPage)
        {
            int schoolsCount = await _context.Schools.CountAsync();
            int totalPages = (int)Math.Ceiling((double)schoolsCount / Constants.DEFAULT_PAGING_SIZE);

            var schools = await _context.Schools
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.Country)
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.City)
                                        .Include(x => x.Ratings)
                                        .Skip((currentPage - 1) * Constants.DEFAULT_PAGING_SIZE)
                                        .Take(Constants.DEFAULT_PAGING_SIZE)
                                        .OrderBy(x => x.Name)
                                        .AsNoTracking().ToArrayAsync();

            var schoolModels = _mapper.Map<IEnumerable<SchoolResponseModel>>(schools).ToArray();

            for (int i = 0; i < schools.Count(); i++)
            {
                schoolModels[i].RatingCount = schools[i].Ratings.Count;
            }

            return new PagingModel<SchoolResponseModel>(currentPage, totalPages, schoolModels);
        }

        public async Task<IEnumerable<SchoolResponseModel>> SearchSchools(SearchSchoolModel searchModel)
        {
            var andQuery = _context.Schools
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.Country)
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.City)
                                        .Include(x => x.Ratings)
                                        .Where(x => x.SchoolType.Equals(searchModel.SelectedSchoolType)
                                                    //x.Specialty.Equals(searchModel.SelectedSpecialty) &&
                                                    //x.TuiTion <= searchModel.TuiTion  &&
                                                    //x.Location.CityId.Equals(searchModel.SelectedCity)
                                                    );
            if (searchModel.SelectedProgram != Guid.Empty)
            {
                andQuery = andQuery.Where(x => x.SchoolEducationPrograms.Any(se => se.EducationProgramId.Equals(searchModel.SelectedProgram)));
            }

            if (searchModel.SelectedCity != Guid.Empty)
            {
                andQuery = andQuery.Where(x => x.Location.CityId.Equals(searchModel.SelectedCity));
            }


            var schools = await andQuery.ToArrayAsync();

            var result = _mapper.Map<IEnumerable<SchoolResponseModel>>(schools).ToArray();

            for (int i = 0; i < schools.Count(); i++)
            {
                result[i].RatingCount = schools[i].Ratings.Count;
            }

            return result;
        }

        public async Task<SchoolResponseModel> GetSchool(Guid id)
        {
            var school = await _context.Schools
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.Country)
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.City)
                                        .AsNoTracking()
                                        .SingleOrDefaultAsync(x => x.Id.Equals(id));

            return _mapper.Map<SchoolResponseModel>(school);
        }

        public async Task<Guid> CreateSchool(SchoolRequestModel requestModel)
        {
            School school = new School()
            {
                Code = requestModel.Code,
                CoverUrl = requestModel.CoverUrl,
                Description = requestModel.Description,
                Name = requestModel.Name,
                TuiTion = requestModel.TuiTion,
                SchoolType = requestModel.SchoolType,
                Website = requestModel.Website
            };

            var programIds = requestModel.Programs.Select(x => x.Id.Value);
            var majorIds = requestModel.Majors.Select(x => x.Id.Value);


            await CreateLocation(requestModel.Location, school.Id);
            await AddSchoolPrograms(programIds, school.Id);
            await AddSchoolMajors(majorIds, school.Id);
            await _context.Schools.AddAsync(school);

            await _context.SaveChangesAsync();

            return school.Id;
        }

        public async Task UpdateSchool(SchoolRequestModel requestModel)
        {
            var school = await _context.Schools
                                        .Include(x => x.Location)
                                        .Include(x => x.SchoolEducationPrograms)
                                        .Include(x => x.SchoolMajors)
                                        .SingleOrDefaultAsync(x => x.Id.Equals(requestModel.Id));

            school.Code = requestModel.Code;
            school.CoverUrl = requestModel.CoverUrl;
            school.Description = requestModel.Description;
            school.Name = requestModel.Name;
            school.TuiTion = requestModel.TuiTion;
            school.SchoolType = requestModel.SchoolType;
            school.Website = requestModel.Website;
            school.Location.CountryId = requestModel.Location.CountryId;
            school.Location.CityId = requestModel.Location.CityId;
            school.Location.District = requestModel.Location.District;
            school.Location.Ward = requestModel.Location.Ward;
            school.Location.Street = requestModel.Location.Street;

            await ChangeProgramsForSchool(requestModel.Programs, school.SchoolEducationPrograms, school.Id);
            await ChangeMajorsForSchool(requestModel.Majors, school.SchoolMajors, school.Id);

            _context.Schools.Update(school);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSchool(Guid id)
        {
            var school = await _context.Schools.SingleOrDefaultAsync(x => x.Id.Equals(id));

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
        }

        private async Task CreateLocation(LocationRequestModel requestModel, Guid schoolId)
        {
            Location location = new Location(
                schoolId,
                requestModel.CityId,
                requestModel.CountryId,
                requestModel.Street,
                requestModel.Ward,
                requestModel.District);

            await _context.Locations.AddAsync(location);
        }

        private async Task AddSchoolPrograms(IEnumerable<Guid> programIds, Guid schoolId)
        {
            var schoolPrograms = new List<SchoolEducationProgram>();

            foreach (var programId in programIds)
            {
                schoolPrograms.Add(new SchoolEducationProgram
                {
                    EducationProgramId = programId,
                    SchoolId = schoolId
                });
            }

            await _context.SchoolEducationPrograms.AddRangeAsync(schoolPrograms);
        }

        private async Task AddSchoolMajors(IEnumerable<Guid> majorIds, Guid schoolId)
        {
            var schoolMajors = new List<SchoolMajor>();

            foreach (var majorId in majorIds)
            {
                schoolMajors.Add(new SchoolMajor
                {
                    MajorId = majorId,
                    SchoolId = schoolId
                });
            }

            await _context.SchoolMajors.AddRangeAsync(schoolMajors);
        }

        private async Task RemoveSchoolPrograms(IEnumerable<Guid> programIds, Guid schoolId)
        {
            var schoolPrograms = await _context.SchoolEducationPrograms
                                                    .Where(x => x.SchoolId.Equals(schoolId) && programIds.Contains(x.EducationProgramId))
                                                    .ToListAsync();

            _context.SchoolEducationPrograms.RemoveRange(schoolPrograms);
        }

        private async Task RemoveSchoolMajors(IEnumerable<Guid> majorIds, Guid schoolId)
        {
            var schoolMajors = await _context.SchoolMajors
                                                .Where(x => x.SchoolId.Equals(schoolId) && majorIds.Contains(x.MajorId))
                                                .ToListAsync();

            _context.SchoolMajors.RemoveRange(schoolMajors);
        }

        private async Task ChangeProgramsForSchool(
            IEnumerable<EducationProgramModel> requestPrograms,
            IEnumerable<SchoolEducationProgram> schoolPrograms,
            Guid schoolId)
        {
            var hashedRequestProgramIds = new HashSet<Guid>(requestPrograms.Select(x => x.Id.Value));
            var hashedSchoolProgramIds = new HashSet<Guid>(schoolPrograms.Select(x => x.EducationProgramId));

            var programsForAdding = hashedRequestProgramIds.Where(x => !hashedSchoolProgramIds.Contains(x));
            var programsForRemove = hashedSchoolProgramIds.Where(x => !hashedRequestProgramIds.Contains(x));

            await AddSchoolPrograms(programsForAdding, schoolId);
            await RemoveSchoolPrograms(programsForRemove, schoolId);
        }

        private async Task ChangeMajorsForSchool(IEnumerable<MajorModel> requestMajors, IEnumerable<SchoolMajor> schoolMajors, Guid schoolId)
        {
            var hashedRequestMajorIds = new HashSet<Guid>(requestMajors.Select(x => x.Id.Value));
            var hashedSchoolMajorIds = new HashSet<Guid>(schoolMajors.Select(x => x.MajorId));

            var majorsForAdding = hashedRequestMajorIds.Where(x => !hashedSchoolMajorIds.Contains(x));
            var majorsForRemove = hashedSchoolMajorIds.Where(x => !hashedRequestMajorIds.Contains(x));

            await AddSchoolMajors(majorsForAdding, schoolId);
            await RemoveSchoolMajors(majorsForRemove, schoolId);
        }
    }
}
