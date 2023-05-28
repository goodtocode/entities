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
    public class AssociateTimeRecurringsController : ControllerBase
    {
        private readonly ChronologyDbContext _dbContext;

        public AssociateTimeRecurringsController(ChronologyDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/AssociateTimeRecurrings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateTimeRecurring>>> GetAssociateTimeRecurring()
        {
            return await _dbContext.AssociateTimeRecurring.ToListAsync();
        }

        // GET: api/AssociateTimeRecurrings/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateTimeRecurring>> GetAssociateTimeRecurring(Guid key)
        {
            var AssociateTimeRecurring = await _dbContext.AssociateTimeRecurring.FindAsync(key);

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

            _dbContext.Entry(AssociateTimeRecurring).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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
            _dbContext.AssociateTimeRecurring.Add(AssociateTimeRecurring);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetAssociateTimeRecurring", new { key = AssociateTimeRecurring.AssociateTimeRecurringKey }, AssociateTimeRecurring);
        }

        // DELETE: api/AssociateTimeRecurrings/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateTimeRecurring>> DeleteAssociateTimeRecurring(Guid key)
        {
            var AssociateTimeRecurring = await _dbContext.AssociateTimeRecurring.FindAsync(key);
            if (AssociateTimeRecurring == null)
            {
                return NotFound();
            }

            _dbContext.AssociateTimeRecurring.Remove(AssociateTimeRecurring);
            await _dbContext.SaveChangesAsync();

            return AssociateTimeRecurring;
        }

        private bool AssociateTimeRecurringExists(Guid key)
        {
            return _dbContext.AssociateTimeRecurring.Any(e => e.AssociateTimeRecurringKey == key);
        }
    }
}
