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
    public class AssociateLocationsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public AssociateLocationsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/AssociateLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateLocation>>> GetAssociateLocation()
        {
            return await _dbContext.AssociateLocation.ToListAsync();
        }

        // GET: api/AssociateLocations/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateLocation>> GetAssociateLocation(Guid key)
        {
            var AssociateLocation = await _dbContext.AssociateLocation.FindAsync(key);

            if (AssociateLocation == null)
            {
                return NotFound();
            }

            return AssociateLocation;
        }

        // PUT: api/AssociateLocations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutAssociateLocation(Guid key, AssociateLocation AssociateLocation)
        {
            if (key != AssociateLocation.AssociateLocationKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(AssociateLocation).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociateLocationExists(key))
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

        // POST: api/AssociateLocations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssociateLocation>> PostAssociateLocation(AssociateLocation AssociateLocation)
        {
            _dbContext.AssociateLocation.Add(AssociateLocation);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetAssociateLocation", new { key = AssociateLocation.AssociateLocationKey }, AssociateLocation);
        }

        // DELETE: api/AssociateLocations/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateLocation>> DeleteAssociateLocation(Guid key)
        {
            var AssociateLocation = await _dbContext.AssociateLocation.FindAsync(key);
            if (AssociateLocation == null)
            {
                return NotFound();
            }

            _dbContext.AssociateLocation.Remove(AssociateLocation);
            await _dbContext.SaveChangesAsync();

            return AssociateLocation;
        }

        private bool AssociateLocationExists(Guid key)
        {
            return _dbContext.AssociateLocation.Any(e => e.AssociateLocationKey == key);
        }
    }
}
