using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSM.Data.Application;
using TSM.Data.Entities;

namespace TSM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly TSMContext _context;

        public SchoolsController(TSMContext context)
        {
            _context = context;
        }

        // GET: api/Schools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            return await _context.Schools.ToListAsync();
        }

        // GET: api/Schools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchool(Guid id)
        {
            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return school;
        }

        // PUT: api/Schools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool(Guid id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }

            _context.Entry(school).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/Schools
        [HttpPost]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchool", new { id = school.Id }, school);
        }

        // DELETE: api/Schools/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<School>> DeleteSchool(Guid id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return school;
        }

        private bool SchoolExists(Guid id)
        {
            return _context.Schools.Any(e => e.Id == id);
        }
    }
}
