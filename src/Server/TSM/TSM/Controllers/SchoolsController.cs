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
using TSM.Models.RequestModels;
using TSM.Models.ResponseModels;

namespace TSM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly IAppLogger<SchoolsController> _logger;
        private readonly ISchoolService _schoolService;
        private readonly ISchoolEducationProgramService _schoolEducationProgramService;
        private readonly ISchoolMajorService _schoolMajorService;

        public SchoolsController(
            IAppLogger<SchoolsController> logger,
            ISchoolService schoolService,
            ISchoolEducationProgramService schoolEducationProgramService,
            ISchoolMajorService schoolMajorService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _schoolService = schoolService ?? throw new ArgumentNullException(nameof(schoolService));
            _schoolEducationProgramService = schoolEducationProgramService ?? throw new ArgumentNullException(nameof(schoolEducationProgramService));
            _schoolMajorService = schoolMajorService ?? throw new ArgumentNullException(nameof(schoolMajorService));
        }

        /// <summary>
        /// Used in search schools with autocomplete and will cache this
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<SchoolResponseModel>>> SearchSchool(SearchSchoolModel searchModel)
        {
            var chools = await _schoolService.SearchSchools(searchModel);
            return Ok(chools);
        }


        [HttpPost("Filter")]
        public async Task<ActionResult<IEnumerable<SchoolResponseModel>>> FilterSchool(int filterType, SearchSchoolModel searchSchoolModel)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolResponseModel>>> GetSchools()
        {
            var schools = await _schoolService.GetSchools();
            return Ok(schools);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolResponseModel>> GetSchool(Guid id)
        {
            var school = await _schoolService.GetSchool(id);

            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        [HttpPost]
        public async Task<ActionResult<SchoolResponseModel>> PostSchool(CreateSchoolRequestModel requestModel)
        {
            var school = await _schoolService.CreateSchool(requestModel);

            return Ok(school);
        }

        [HttpPut]
        public async Task<ActionResult<SchoolResponseModel>> PutSchool(UpdateSchoolRequestModel requestModel)
        {
            var school = await _schoolService.UpdateSchool(requestModel);

            return Ok(school);
        }

        [HttpGet("{id}/majors")]
        public async Task<ActionResult<IEnumerable<MajorModel>>> GetSchoolMajors(Guid id)
        {
            var majors = await _schoolMajorService.SchoolMajors(id);

            if (majors == null)
            {
                return NotFound();
            }

            return Ok(majors);
        }

        [HttpPost("{id}/majors")]
        public async Task<IActionResult> PostSchoolMajors(Guid id, List<Guid> majorIds)
        {
            await _schoolMajorService.AddSchoolMajors(id, majorIds);

            return Ok();
        }

        [HttpDelete("{id}/majors")]
        public async Task<IActionResult> DeleteSchoolMajors(Guid id, List<Guid> majorIds)
        {
            await _schoolMajorService.RemoveSchoolMajors(id, majorIds);

            return Ok();
        }

        [HttpGet("{id}/programs")]
        public async Task<ActionResult<IEnumerable<MajorModel>>> GetSchoolPrograms(Guid id)
        {
            var programs = await _schoolEducationProgramService.SchoolEducationPrograms(id);

            if (programs == null)
            {
                return NotFound();
            }

            return Ok(programs);
        }

        [HttpPost("{id}/programs")]
        public async Task<IActionResult> PostSchoolPrograms(Guid id, List<Guid> programIds)
        {
            await _schoolEducationProgramService.AddSchoolEducationPrograms(id, programIds);

            return Ok();
        }

        [HttpDelete("{id}/programs")]
        public async Task<IActionResult> DeleteSchoolPrograms(Guid id, List<Guid> programIds)
        {
            await _schoolEducationProgramService.RemoveSchoolEducationPrograms(id, programIds);

            return Ok();
        }
    }
}
