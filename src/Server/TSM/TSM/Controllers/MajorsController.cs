using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSM.Data.Application;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models;

namespace TSM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly IAppLogger<MajorsController> _logger;
        private readonly IMajorService _majorService;

        public MajorsController(
            IAppLogger<MajorsController> logger,
            IMajorService majorService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _majorService = majorService ?? throw new ArgumentNullException(nameof(majorService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MajorModel>>> GetMajors()
        {
            _logger.LogInformation("GetMajors");

            var majors = await _majorService.GetMajors();
            return Ok(majors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MajorModel>> GetMajor(Guid id)
        {
            _logger.LogInformation($"GetMajor {id}");

            var major = await _majorService.GetMajor(id);

            if (major == null)
            {
                return NotFound();
            }

            return Ok(major);
        }

        [HttpPost]
        public async Task<ActionResult<MajorModel>> PostMajor(MajorModel majorModel)
        {
            _logger.LogInformation($"PostMajor {majorModel}");

            var major = await _majorService.CreateMajor(majorModel);

            return Ok(major);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMajor(Guid id)
        {
            _logger.LogInformation($"DeleteMajor {id}");

            await _majorService.DeleteMajor(id);
            return Ok();
        }

    }
}
