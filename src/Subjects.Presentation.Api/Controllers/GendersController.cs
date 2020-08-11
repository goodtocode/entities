using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public GendersController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGender()
        {
            return await _context.Gender.ToListAsync();
        }

        // GET: api/Genders/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Gender>> GetGender(Guid key)
        {
            var gender = await _context.Gender.FindAsync(key);

            if (gender == null)
            {
                return NotFound();
            }

            return gender;
        }

        // PUT: api/Genders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutGender(Guid key, Gender gender)
        {
            if (key != gender.GenderKey)
            {
                return BadRequest();
            }

            _context.Entry(gender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderExists(key))
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

        // POST: api/Genders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gender>> PostGender(Gender gender)
        {
            _context.Gender.Add(gender);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GenderExists(gender.GenderKey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGender", new { key = gender.GenderKey }, gender);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Gender>> DeleteGender(Guid key)
        {
            var gender = await _context.Gender.FindAsync(key);
            if (gender == null)
            {
                return NotFound();
            }

            _context.Gender.Remove(gender);
            await _context.SaveChangesAsync();

            return gender;
        }

        private bool GenderExists(Guid key)
        {
            return _context.Gender.Any(e => e.GenderKey == key);
        }
    }
}
