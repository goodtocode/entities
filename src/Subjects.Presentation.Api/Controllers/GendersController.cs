using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public GendersController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGender()
        {
            return await _dbContext.Gender.ToListAsync();
        }

        // GET: api/Genders/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Gender>> GetGender(Guid key)
        {
            var gender = await _dbContext.Gender.FindAsync(key);

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

            _dbContext.Entry(gender).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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
            _dbContext.Gender.Add(gender);
            try
            {
                await _dbContext.SaveChangesAsync();
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
            var gender = await _dbContext.Gender.FindAsync(key);
            if (gender == null)
            {
                return NotFound();
            }

            _dbContext.Gender.Remove(gender);
            await _dbContext.SaveChangesAsync();

            return gender;
        }

        private bool GenderExists(Guid key)
        {
            return _dbContext.Gender.Any(e => e.GenderKey == key);
        }
    }
}
