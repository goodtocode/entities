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
    public class EntityLocationsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EntityLocationsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/EntityLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityLocation>>> GetEntityLocation()
        {
            return await _context.EntityLocation.ToListAsync();
        }

        // GET: api/EntityLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityLocation>> GetEntityLocation(int id)
        {
            var entityLocation = await _context.EntityLocation.FindAsync(id);

            if (entityLocation == null)
            {
                return NotFound();
            }

            return entityLocation;
        }

        // PUT: api/EntityLocations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityLocation(int id, EntityLocation entityLocation)
        {
            if (id != entityLocation.EntityLocationId)
            {
                return BadRequest();
            }

            _context.Entry(entityLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityLocationExists(id))
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

        // POST: api/EntityLocations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EntityLocation>> PostEntityLocation(EntityLocation entityLocation)
        {
            _context.EntityLocation.Add(entityLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityLocation", new { id = entityLocation.EntityLocationId }, entityLocation);
        }

        // DELETE: api/EntityLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EntityLocation>> DeleteEntityLocation(int id)
        {
            var entityLocation = await _context.EntityLocation.FindAsync(id);
            if (entityLocation == null)
            {
                return NotFound();
            }

            _context.EntityLocation.Remove(entityLocation);
            await _context.SaveChangesAsync();

            return entityLocation;
        }

        private bool EntityLocationExists(int id)
        {
            return _context.EntityLocation.Any(e => e.EntityLocationId == id);
        }
    }
}
