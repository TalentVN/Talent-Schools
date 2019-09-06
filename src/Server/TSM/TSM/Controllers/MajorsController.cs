using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models;

namespace TSM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
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

        [HttpGet("Page/{currentPage}")]
        public async Task<ActionResult<PagingModel<MajorModel>>> GetPagingMajors(int currentPage)
        {
            _logger.LogInformation("GetPagingMajors");

            if (currentPage < 1)
            {
                return NotFound();
            }

            var pagingModel = await _majorService.GetPagingMajors(currentPage);
            return Ok(pagingModel);
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
        public async Task<IActionResult> PostMajor(MajorModel majorModel)
        {
            _logger.LogInformation($"PostMajor {majorModel}");

            await _majorService.CreateMajor(majorModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutMajor(MajorModel major)
        {
            _logger.LogInformation($"PutMajor {major}");

            await _majorService.UpdateMajor(major);

            return Ok();
        }

        [HttpPost("ChangeActive/{id}")]
        public async Task<IActionResult> ChangeActiveMajor(string id)
        {
            _logger.LogInformation($"ChangeActiveMajor {id}");

            await _majorService.ChangeActiveMajor(Guid.Parse(id));

            return Ok();
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
