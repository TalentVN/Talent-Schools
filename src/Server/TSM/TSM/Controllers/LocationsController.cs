using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Models.ResponseModels;

namespace TSM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(
            ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("Cities")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _locationService.GetCities();
            return Ok(cities);
        }
    }
}