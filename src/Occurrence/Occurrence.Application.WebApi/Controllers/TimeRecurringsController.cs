using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Subjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRecurringsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public TimeRecurringsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/TimeRecurrings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeRecurring>>> GetTimeRecurring()
        {
            return await _context.TimeRecurring.ToListAsync();
        }

        // GET: api/TimeRecurrings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeRecurring>> GetTimeRecurring(int id)
        {
            var timeRecurring = await _context.TimeRecurring.FindAsync(id);

            if (timeRecurring == null)
            {
                return NotFound();
            }

            return timeRecurring;
        }

        // PUT: api/TimeRecurrings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeRecurring(int id, TimeRecurring timeRecurring)
        {
            if (id != timeRecurring.TimeRecurringId)
            {
                return BadRequest();
            }

            _context.Entry(timeRecurring).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeRecurringExists(id))
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

        // POST: api/TimeRecurrings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TimeRecurring>> PostTimeRecurring(TimeRecurring timeRecurring)
        {
            _context.TimeRecurring.Add(timeRecurring);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeRecurring", new { id = timeRecurring.TimeRecurringId }, timeRecurring);
        }

        // DELETE: api/TimeRecurrings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeRecurring>> DeleteTimeRecurring(int id)
        {
            var timeRecurring = await _context.TimeRecurring.FindAsync(id);
            if (timeRecurring == null)
            {
                return NotFound();
            }

            _context.TimeRecurring.Remove(timeRecurring);
            await _context.SaveChangesAsync();

            return timeRecurring;
        }

        private bool TimeRecurringExists(int id)
        {
            return _context.TimeRecurring.Any(e => e.TimeRecurringId == id);
        }
    }
}
