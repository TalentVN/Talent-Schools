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
    public class EducationProgramsController : ControllerBase
    {
        private readonly IAppLogger<EducationProgramsController> _logger;
        private readonly IEducationProgramService _educationProgramService;

        public EducationProgramsController(
            IAppLogger<EducationProgramsController> logger,
            IEducationProgramService educationProgramService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _educationProgramService = educationProgramService ?? throw new ArgumentNullException(nameof(educationProgramService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationProgramModel>>> GetEducationPrograms()
        {
            _logger.LogInformation("GetEducationPrograms");

            var programs = await _educationProgramService.GetEducationPrograms();

            return Ok(programs);
        }

        [HttpGet("Page/{currentPage}")]
        public async Task<ActionResult<PagingModel<EducationProgramModel>>> GetPagingEducationPrograms(int currentPage)
        {
            _logger.LogInformation("GetPagingEducationPrograms");

            if(currentPage < 1)
            {
                return NotFound();
            }

            var pagingModel = await _educationProgramService.GetPagingEducationPrograms(currentPage);

            return Ok(pagingModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationProgramModel>> GetEducationProgram(Guid id)
        {
            _logger.LogInformation($"GetMajor {id}");

            var program = await _educationProgramService.GetEducationProgram(id);

            if (program == null)
            {
                return NotFound();
            }

            return Ok(program);
        }

        [HttpPost]
        public async Task<IActionResult> PostEducationProgram(EducationProgramModel educationProgram)
        {
            _logger.LogInformation($"PostEducationProgram {educationProgram}");

            await _educationProgramService.CreateEducationProgram(educationProgram);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutEducationProgram(EducationProgramModel educationProgram)
        {
            _logger.LogInformation($"PutEducationProgram {educationProgram}");

            await _educationProgramService.UpdateEducationProgram(educationProgram);

            return Ok();
        }

        [HttpPost("ChangeActive/{id}")]
        public async Task<IActionResult> ChangeActiveEducationProgram(string id)
        {
            _logger.LogInformation($"ChangeActiveEducationProgram {id}");

            await _educationProgramService.ChangeActiveEducationProgram(Guid.Parse(id));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationProgram(Guid id)
        {
            _logger.LogInformation($"DeleteEducationProgram {id}");

            await _educationProgramService.DeleteEducationProgram(id);

            return Ok();
        }
    }
}
