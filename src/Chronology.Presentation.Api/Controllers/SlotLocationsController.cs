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
    public class SlotLocationsController : ControllerBase
    {
        private readonly ChronoloyDbContext _context;

        public SlotLocationsController(ChronoloyDbContext context)
        {
            _context = context;
        }

        // GET: api/SlotLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlotLocation>>> GetSlotLocation()
        {
            return await _context.SlotLocation.ToListAsync();
        }

        // GET: api/SlotLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SlotLocation>> GetSlotLocation(int id)
        {
            var slotLocation = await _context.SlotLocation.FindAsync(id);

            if (slotLocation == null)
            {
                return NotFound();
            }

            return slotLocation;
        }

        // PUT: api/SlotLocations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlotLocation(int id, SlotLocation slotLocation)
        {
            if (id != slotLocation.SlotLocationId)
            {
                return BadRequest();
            }

            _context.Entry(slotLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlotLocationExists(id))
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

        // POST: api/SlotLocations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SlotLocation>> PostSlotLocation(SlotLocation slotLocation)
        {
            _context.SlotLocation.Add(slotLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSlotLocation", new { id = slotLocation.SlotLocationId }, slotLocation);
        }

        // DELETE: api/SlotLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SlotLocation>> DeleteSlotLocation(int id)
        {
            var slotLocation = await _context.SlotLocation.FindAsync(id);
            if (slotLocation == null)
            {
                return NotFound();
            }

            _context.SlotLocation.Remove(slotLocation);
            await _context.SaveChangesAsync();

            return slotLocation;
        }

        private bool SlotLocationExists(int id)
        {
            return _context.SlotLocation.Any(e => e.SlotLocationId == id);
        }
    }
}
