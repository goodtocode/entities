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
    public class ResourceSchedulesController : ControllerBase
    {
        private readonly ChronologyDbContext _dbContext;

        public ResourceSchedulesController(ChronologyDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/ResourceSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceSchedule>>> GetResourceSchedule()
        {
            return await _dbContext.ResourceSchedule.ToListAsync();
        }

        // GET: api/ResourceSchedules/5
        [HttpGet("{key}")]
        public async Task<ActionResult<ResourceSchedule>> GetResourceSchedule(Guid key)
        {
            var ResourceSchedule = await _dbContext.ResourceSchedule.FindAsync(key);

            if (ResourceSchedule == null)
            {
                return NotFound();
            }

            return ResourceSchedule;
        }

        // PUT: api/ResourceSchedules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutResourceSchedule(Guid key, ResourceSchedule ResourceSchedule)
        {
            if (key != ResourceSchedule.ResourceScheduleKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(ResourceSchedule).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceScheduleExists(key))
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

        // POST: api/ResourceSchedules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ResourceSchedule>> PostResourceSchedule(ResourceSchedule ResourceSchedule)
        {
            _dbContext.ResourceSchedule.Add(ResourceSchedule);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetResourceSchedule", new { key = ResourceSchedule.ResourceScheduleKey }, ResourceSchedule);
        }

        // DELETE: api/ResourceSchedules/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<ResourceSchedule>> DeleteResourceSchedule(Guid key)
        {
            var ResourceSchedule = await _dbContext.ResourceSchedule.FindAsync(key);
            if (ResourceSchedule == null)
            {
                return NotFound();
            }

            _dbContext.ResourceSchedule.Remove(ResourceSchedule);
            await _dbContext.SaveChangesAsync();

            return ResourceSchedule;
        }

        private bool ResourceScheduleExists(Guid key)
        {
            return _dbContext.ResourceSchedule.Any(e => e.ResourceScheduleKey == key);
        }
    }
}
