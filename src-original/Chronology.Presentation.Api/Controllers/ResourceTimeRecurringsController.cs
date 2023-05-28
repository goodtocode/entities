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
    public class ResourceTimeRecurringsController : ControllerBase
    {
        private readonly ChronologyDbContext _dbContext;

        public ResourceTimeRecurringsController(ChronologyDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/ResourceTimeRecurrings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceTimeRecurring>>> GetResourceTimeRecurring()
        {
            return await _dbContext.ResourceTimeRecurring.ToListAsync();
        }

        // GET: api/ResourceTimeRecurrings/5
        [HttpGet("{key}")]
        public async Task<ActionResult<ResourceTimeRecurring>> GetResourceTimeRecurring(Guid key)
        {
            var ResourceTimeRecurring = await _dbContext.ResourceTimeRecurring.FindAsync(key);

            if (ResourceTimeRecurring == null)
            {
                return NotFound();
            }

            return ResourceTimeRecurring;
        }

        // PUT: api/ResourceTimeRecurrings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutResourceTimeRecurring(Guid key, ResourceTimeRecurring ResourceTimeRecurring)
        {
            if (key != ResourceTimeRecurring.ResourceTimeRecurringKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(ResourceTimeRecurring).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceTimeRecurringExists(key))
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

        // POST: api/ResourceTimeRecurrings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ResourceTimeRecurring>> PostResourceTimeRecurring(ResourceTimeRecurring ResourceTimeRecurring)
        {
            _dbContext.ResourceTimeRecurring.Add(ResourceTimeRecurring);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetResourceTimeRecurring", new { key = ResourceTimeRecurring.ResourceTimeRecurringKey }, ResourceTimeRecurring);
        }

        // DELETE: api/ResourceTimeRecurrings/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<ResourceTimeRecurring>> DeleteResourceTimeRecurring(Guid key)
        {
            var ResourceTimeRecurring = await _dbContext.ResourceTimeRecurring.FindAsync(key);
            if (ResourceTimeRecurring == null)
            {
                return NotFound();
            }

            _dbContext.ResourceTimeRecurring.Remove(ResourceTimeRecurring);
            await _dbContext.SaveChangesAsync();

            return ResourceTimeRecurring;
        }

        private bool ResourceTimeRecurringExists(Guid key)
        {
            return _dbContext.ResourceTimeRecurring.Any(e => e.ResourceTimeRecurringKey == key);
        }
    }
}
