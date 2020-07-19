using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Entities.WebApi1.Models;

namespace GoodToCode.Entities.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLocationsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EventLocationsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/EventLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventLocation>>> GetEventLocation()
        {
            return await _context.EventLocation.ToListAsync();
        }

        // GET: api/EventLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventLocation>> GetEventLocation(int id)
        {
            var eventLocation = await _context.EventLocation.FindAsync(id);

            if (eventLocation == null)
            {
                return NotFound();
            }

            return eventLocation;
        }

        // PUT: api/EventLocations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventLocation(int id, EventLocation eventLocation)
        {
            if (id != eventLocation.EventLocationId)
            {
                return BadRequest();
            }

            _context.Entry(eventLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventLocationExists(id))
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

        // POST: api/EventLocations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventLocation>> PostEventLocation(EventLocation eventLocation)
        {
            _context.EventLocation.Add(eventLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventLocation", new { id = eventLocation.EventLocationId }, eventLocation);
        }

        // DELETE: api/EventLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventLocation>> DeleteEventLocation(int id)
        {
            var eventLocation = await _context.EventLocation.FindAsync(id);
            if (eventLocation == null)
            {
                return NotFound();
            }

            _context.EventLocation.Remove(eventLocation);
            await _context.SaveChangesAsync();

            return eventLocation;
        }

        private bool EventLocationExists(int id)
        {
            return _context.EventLocation.Any(e => e.EventLocationId == id);
        }
    }
}
