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
using TSM.Models.ResponseModels;

namespace TSM.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<SchoolService> _logger;
        private readonly TSMContext _context;

        public SchoolService(
            IMapper mapper,
            IAppLogger<SchoolService> logger,
            TSMContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<SchoolResponseModel>> GetSchools()
        {
            var schools = await _context.Schools
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.Country)
                                        .Include(x => x.Location)
                                            .ThenInclude(l => l.City)
                                        .ToListAsync();

            return _mapper.Map<IEnumerable<SchoolResponseModel>>(schools);
        }
    }
}
