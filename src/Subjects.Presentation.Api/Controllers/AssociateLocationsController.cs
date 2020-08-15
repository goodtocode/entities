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
        private readonly SubjectsDbContext _context;

        public AssociateLocationsController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/AssociateLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateLocation>>> GetAssociateLocation()
        {
            return await _context.AssociateLocation.ToListAsync();
        }

        // GET: api/AssociateLocations/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateLocation>> GetAssociateLocation(Guid key)
        {
            var AssociateLocation = await _context.AssociateLocation.FindAsync(key);

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

            _context.Entry(AssociateLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            _context.AssociateLocation.Add(AssociateLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssociateLocation", new { key = AssociateLocation.AssociateLocationKey }, AssociateLocation);
        }

        // DELETE: api/AssociateLocations/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateLocation>> DeleteAssociateLocation(Guid key)
        {
            var AssociateLocation = await _context.AssociateLocation.FindAsync(key);
            if (AssociateLocation == null)
            {
                return NotFound();
            }

            _context.AssociateLocation.Remove(AssociateLocation);
            await _context.SaveChangesAsync();

            return AssociateLocation;
        }

        private bool AssociateLocationExists(Guid key)
        {
            return _context.AssociateLocation.Any(e => e.AssociateLocationKey == key);
        }
    }
}
