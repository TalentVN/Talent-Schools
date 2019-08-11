using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<SchoolResponseModel>> GetSchools()
        {
            var schools = await _context.Schools
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.Country)
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.City)
                                        .Include(x => x.Ratings)
                                        .OrderBy(x => x.Name)
                                        .AsNoTracking()
                                        .ToArrayAsync();

            var result = _mapper.Map<IEnumerable<SchoolResponseModel>>(schools).ToArray();

            for (int i = 0; i < schools.Count(); i++)
            {
                result[i].RatingCount = schools[i].Ratings.Count;
            }

            return result;
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
                result[i].RatingCount = schools[i].Ratings.Count();
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

        public async Task CreateSchool(CreateSchoolRequestModel requestModel)
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

            await CreateLocation(requestModel.Location, school.Id);

            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
        }

        private async Task<Location> CreateLocation(LocationRequestModel requestModel, Guid schoolId)
        {
            Location location = new Location(
                schoolId,
                requestModel.CityId,
                requestModel.CountryId,
                requestModel.Street,
                requestModel.Ward,
                requestModel.District);

            await _context.Locations.AddAsync(location);

            return location;
        }

        public async Task UpdateSchool(UpdateSchoolRequestModel requestModel)
        {
            var school = await _context.Schools
                                        .Include(x => x.Location)
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

            _context.Schools.Update(school);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSchool(Guid id)
        {
            var school = await _context.Schools.SingleOrDefaultAsync(x => x.Id.Equals(id));

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
        }
    }
}
