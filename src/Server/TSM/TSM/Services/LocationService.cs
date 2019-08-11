using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Application;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Models.ResponseModels;

namespace TSM.Services
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly TSMContext _context;

        public LocationService(
            IMapper mapper,
            TSMContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await _context.Cities.OrderBy(x => x.Name).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Countries.OrderBy(x => x.Name).AsNoTracking().ToListAsync();
        }
    }
}
