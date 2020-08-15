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
    public class AssociateTimeRecurringsController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public AssociateTimeRecurringsController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/AssociateTimeRecurrings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateTimeRecurring>>> GetAssociateTimeRecurring()
        {
            return await _context.AssociateTimeRecurring.ToListAsync();
        }

        // GET: api/AssociateTimeRecurrings/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateTimeRecurring>> GetAssociateTimeRecurring(Guid key)
        {
            var AssociateTimeRecurring = await _context.AssociateTimeRecurring.FindAsync(key);

            if (AssociateTimeRecurring == null)
            {
                return NotFound();
            }

            return AssociateTimeRecurring;
        }

        // PUT: api/AssociateTimeRecurrings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutAssociateTimeRecurring(Guid key, AssociateTimeRecurring AssociateTimeRecurring)
        {
            if (key != AssociateTimeRecurring.AssociateTimeRecurringKey)
            {
                return BadRequest();
            }

            _context.Entry(AssociateTimeRecurring).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociateTimeRecurringExists(key))
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

        // POST: api/AssociateTimeRecurrings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssociateTimeRecurring>> PostAssociateTimeRecurring(AssociateTimeRecurring AssociateTimeRecurring)
        {
            _context.AssociateTimeRecurring.Add(AssociateTimeRecurring);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssociateTimeRecurring", new { key = AssociateTimeRecurring.AssociateTimeRecurringKey }, AssociateTimeRecurring);
        }

        // DELETE: api/AssociateTimeRecurrings/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateTimeRecurring>> DeleteAssociateTimeRecurring(Guid key)
        {
            var AssociateTimeRecurring = await _context.AssociateTimeRecurring.FindAsync(key);
            if (AssociateTimeRecurring == null)
            {
                return NotFound();
            }

            _context.AssociateTimeRecurring.Remove(AssociateTimeRecurring);
            await _context.SaveChangesAsync();

            return AssociateTimeRecurring;
        }

        private bool AssociateTimeRecurringExists(Guid key)
        {
            return _context.AssociateTimeRecurring.Any(e => e.AssociateTimeRecurringKey == key);
        }
    }
}
