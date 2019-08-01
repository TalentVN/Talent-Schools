using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class EducationProgramsController : ControllerBase
    {
        private readonly IAppLogger<EducationProgramsController> _logger;
        private readonly IEducationProgramService _educationProgramService;

        public EducationProgramsController(
            IAppLogger<EducationProgramsController> logger,
            IEducationProgramService educationProgramService)
        {
            _logger = logger;
            _educationProgramService = educationProgramService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationProgramModel>>> GetEducationPrograms()
        {
            _logger.LogInformation("GetEducationPrograms");

            var programs = await _educationProgramService.GetEducationPrograms();

            return Ok(programs);
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
        public async Task<ActionResult<EducationProgramModel>> PostEducationProgram(EducationProgramModel educationProgram)
        {
            _logger.LogInformation($"PostEducationProgram {educationProgram}");

            var program = await _educationProgramService.CreateEducationProgram(educationProgram);

            return Ok(program);
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
