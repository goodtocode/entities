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
    public class AssociateSchedulesController : ControllerBase
    {
        private readonly ChronologyDbContext _dbContext;

        public AssociateSchedulesController(ChronologyDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/AssociateSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateSchedule>>> GetAssociateSchedule()
        {
            return await _dbContext.AssociateSchedule.ToListAsync();
        }

        // GET: api/AssociateSchedules/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateSchedule>> GetAssociateSchedule(Guid key)
        {
            var AssociateSchedule = await _dbContext.AssociateSchedule.FindAsync(key);

            if (AssociateSchedule == null)
            {
                return NotFound();
            }

            return AssociateSchedule;
        }

        // PUT: api/AssociateSchedules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutAssociateSchedule(Guid key, AssociateSchedule AssociateSchedule)
        {
            if (key != AssociateSchedule.AssociateScheduleKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(AssociateSchedule).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociateScheduleExists(key))
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

        // POST: api/AssociateSchedules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssociateSchedule>> PostAssociateSchedule(AssociateSchedule AssociateSchedule)
        {
            _dbContext.AssociateSchedule.Add(AssociateSchedule);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetAssociateSchedule", new { key = AssociateSchedule.AssociateScheduleKey }, AssociateSchedule);
        }

        // DELETE: api/AssociateSchedules/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateSchedule>> DeleteAssociateSchedule(Guid key)
        {
            var AssociateSchedule = await _dbContext.AssociateSchedule.FindAsync(key);
            if (AssociateSchedule == null)
            {
                return NotFound();
            }

            _dbContext.AssociateSchedule.Remove(AssociateSchedule);
            await _dbContext.SaveChangesAsync();

            return AssociateSchedule;
        }

        private bool AssociateScheduleExists(Guid key)
        {
            return _dbContext.AssociateSchedule.Any(e => e.AssociateScheduleKey == key);
        }
    }
}
