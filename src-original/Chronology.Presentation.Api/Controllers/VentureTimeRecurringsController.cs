using GoodToCode.Chronology.Infrastructure;
using GoodToCode.Chronology.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Chronology.Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentureTimeRecurringsController : ControllerBase
    {
        private readonly ChronologyDbContext _dbContext;

        public VentureTimeRecurringsController(ChronologyDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/VentureTimeRecurrings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureTimeRecurring>>> GetVentureTimeRecurring()
        {
            return await _dbContext.VentureTimeRecurring.ToListAsync();
        }

        // GET: api/VentureTimeRecurrings/5
        [HttpGet("{key}")]
        public async Task<ActionResult<VentureTimeRecurring>> GetVentureTimeRecurring(Guid key)
        {
            var VentureTimeRecurring = await _dbContext.VentureTimeRecurring.FindAsync(key);

            if (VentureTimeRecurring == null)
            {
                return NotFound();
            }

            return VentureTimeRecurring;
        }

        // PUT: api/VentureTimeRecurrings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutVentureTimeRecurring(Guid key, VentureTimeRecurring VentureTimeRecurring)
        {
            if (key != VentureTimeRecurring.VentureTimeRecurringKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(VentureTimeRecurring).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureTimeRecurringExists(key))
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

        // POST: api/VentureTimeRecurrings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VentureTimeRecurring>> PostVentureTimeRecurring(VentureTimeRecurring VentureTimeRecurring)
        {
            _dbContext.VentureTimeRecurring.Add(VentureTimeRecurring);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetVentureTimeRecurring", new { key = VentureTimeRecurring.VentureTimeRecurringKey }, VentureTimeRecurring);
        }

        // DELETE: api/VentureTimeRecurrings/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<VentureTimeRecurring>> DeleteVentureTimeRecurring(Guid key)
        {
            var VentureTimeRecurring = await _dbContext.VentureTimeRecurring.FindAsync(key);
            if (VentureTimeRecurring == null)
            {
                return NotFound();
            }

            _dbContext.VentureTimeRecurring.Remove(VentureTimeRecurring);
            await _dbContext.SaveChangesAsync();

            return VentureTimeRecurring;
        }

        private bool VentureTimeRecurringExists(Guid key)
        {
            return _dbContext.VentureTimeRecurring.Any(e => e.VentureTimeRecurringKey == key);
        }
    }
}
