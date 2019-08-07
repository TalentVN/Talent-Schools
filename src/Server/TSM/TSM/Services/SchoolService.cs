using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Application;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Logging;
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
                                        .ToArrayAsync();

            var result = _mapper.Map<IEnumerable<SchoolResponseModel>>(schools).ToArray();

            for(int i = 0; i < schools.Count(); i++)
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
    }
}
