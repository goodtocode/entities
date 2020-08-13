using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Shared.Models;

namespace GoodToCode.Chronology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRangesController : ControllerBase
    {
        private readonly ChronoloyDbContext _context;

        public TimeRangesController(ChronoloyDbContext context)
        {
            _context = context;
        }

        // GET: api/TimeRanges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeRange>>> GetTimeRange()
        {
            return await _context.TimeRange.ToListAsync();
        }

        // GET: api/TimeRanges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeRange>> GetTimeRange(int id)
        {
            var timeRange = await _context.TimeRange.FindAsync(id);

            if (timeRange == null)
            {
                return NotFound();
            }

            return timeRange;
        }

        // PUT: api/TimeRanges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeRange(int id, TimeRange timeRange)
        {
            if (id != timeRange.TimeRangeId)
            {
                return BadRequest();
            }

            _context.Entry(timeRange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeRangeExists(id))
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

        // POST: api/TimeRanges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TimeRange>> PostTimeRange(TimeRange timeRange)
        {
            _context.TimeRange.Add(timeRange);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeRange", new { id = timeRange.TimeRangeId }, timeRange);
        }

        // DELETE: api/TimeRanges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeRange>> DeleteTimeRange(int id)
        {
            var timeRange = await _context.TimeRange.FindAsync(id);
            if (timeRange == null)
            {
                return NotFound();
            }

            _context.TimeRange.Remove(timeRange);
            await _context.SaveChangesAsync();

            return timeRange;
        }

        private bool TimeRangeExists(int id)
        {
            return _context.TimeRange.Any(e => e.TimeRangeId == id);
        }
    }
}
