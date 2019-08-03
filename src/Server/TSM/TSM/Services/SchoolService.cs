using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSM.Data.Application;
using TSM.Data.Entities;
using TSM.Interfaces;
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
                                        .AsNoTracking()
                                        .ToListAsync();

            return _mapper.Map<IEnumerable<SchoolResponseModel>>(schools);
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

        public async Task<SchoolResponseModel> CreateSchool(CreateSchoolRequestModel requestModel)
        {
            Location location = await CreateLocation(requestModel.Location);

            School school = new School()
            {
                Code = requestModel.Code,
                CoverUrl = requestModel.CoverUrl,
                Description = requestModel.Description,
                Name = requestModel.Name,
                TuiTion = requestModel.TuiTion,
                SchoolType = requestModel.SchoolType,
                Website = requestModel.Website,
                Location = location
            };

            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();

            return _mapper.Map<SchoolResponseModel>(school);
        }

        private async Task<Location> CreateLocation(LocationRequestModel requestModel)
        {
            Location location = new Location(
                requestModel.CityId,
                requestModel.CountryId,
                requestModel.Street,
                requestModel.Ward,
                requestModel.District);

            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return location;
        }

        public async Task<SchoolResponseModel> UpdateSchool(UpdateSchoolRequestModel requestModel)
        {
            var school = await _context.Schools
                                        .Include(x => x.Location)
                                        .SingleOrDefaultAsync(x => x.Equals(requestModel.Id));

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

            return _mapper.Map<SchoolResponseModel>(school);
        }

        public async Task DeleteSchool(Guid id)
        {
            var school = await _context.Schools.SingleOrDefaultAsync(x => x.Id.Equals(id));

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
        }
    }
}
