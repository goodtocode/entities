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
    public class GovernmentsController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public GovernmentsController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/Governments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Government>>> GetGovernment()
        {
            return await _context.Government.ToListAsync();
        }

        // GET: api/Governments/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Government>> GetGovernment(Guid key)
        {
            var government = await _context.Government.FindAsync(key);

            if (government == null)
            {
                return NotFound();
            }

            return government;
        }

        // PUT: api/Governments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutGovernment(Guid key, Government government)
        {
            if (key != government.GovernmentKey)
            {
                return BadRequest();
            }

            _context.Entry(government).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GovernmentExists(key))
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

        // POST: api/Governments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Government>> PostGovernment(Government government)
        {
            _context.Government.Add(government);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGovernment", new { key = government.GovernmentKey }, government);
        }

        // DELETE: api/Governments/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Government>> DeleteGovernment(Guid key)
        {
            var government = await _context.Government.FindAsync(key);
            if (government == null)
            {
                return NotFound();
            }

            _context.Government.Remove(government);
            await _context.SaveChangesAsync();

            return government;
        }

        private bool GovernmentExists(Guid key)
        {
            return _context.Government.Any(e => e.GovernmentKey == key);
        }
    }
}
