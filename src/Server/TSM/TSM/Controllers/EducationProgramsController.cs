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
using TSM.Models;

namespace TSM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationProgramsController : ControllerBase
    {
        private readonly TSMContext _context;
        private readonly IMapper _mapper;
        private readonly IEducationProgramService _educationProgramService;

        public EducationProgramsController(
            TSMContext context,
            IMapper mapper,
            IEducationProgramService educationProgramService)
        {
            _context = context;
            _mapper = mapper;
            _educationProgramService = educationProgramService;
        }

        // GET: api/EducationPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationProgram>>> GetEducationPrograms()
        {
            return await _context.EducationPrograms.ToListAsync();
        }

        // GET: api/EducationPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationProgram>> GetEducationProgram(Guid id)
        {
            var educationProgram = await _context.EducationPrograms.FindAsync(id);

            if (educationProgram == null)
            {
                return NotFound();
            }

            return educationProgram;
        }

        // GET: api/EducationPrograms
        [HttpPost("SchoolEducationPrograms")]
        public async Task<ActionResult<IEnumerable<EducationProgramModel>>> GetBySchoolId(Guid schoolId)
        {
            var programs = await _educationProgramService.GetBySchoolId(schoolId);

            if (programs == null)
            {
                return NotFound();
            }

            return Ok(programs);
        }

        // PUT: api/EducationPrograms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationProgram(Guid id, EducationProgram educationProgram)
        {
            if (id != educationProgram.Id)
            {
                return BadRequest();
            }

            _context.Entry(educationProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationProgramExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<EducationProgram>> PostEducationProgram(EducationProgram educationProgram)
        {
            _context.EducationPrograms.Add(educationProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationProgram", new { id = educationProgram.Id }, educationProgram);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EducationProgram>> DeleteEducationProgram(Guid id)
        {
            var educationProgram = await _context.EducationPrograms.FindAsync(id);
            if (educationProgram == null)
            {
                return NotFound();
            }

            _context.EducationPrograms.Remove(educationProgram);
            await _context.SaveChangesAsync();

            return educationProgram;
        }

        private bool EducationProgramExists(Guid id)
        {
            return _context.EducationPrograms.Any(e => e.Id == id);
        }
    }
}
