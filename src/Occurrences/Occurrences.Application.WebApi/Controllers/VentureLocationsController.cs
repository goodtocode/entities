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
    public class VentureLocationsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public VentureLocationsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/VentureLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureLocation>>> GetVentureLocation()
        {
            return await _context.VentureLocation.ToListAsync();
        }

        // GET: api/VentureLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentureLocation>> GetVentureLocation(int id)
        {
            var ventureLocation = await _context.VentureLocation.FindAsync(id);

            if (ventureLocation == null)
            {
                return NotFound();
            }

            return ventureLocation;
        }

        // PUT: api/VentureLocations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentureLocation(int id, VentureLocation ventureLocation)
        {
            if (id != ventureLocation.VentureLocationId)
            {
                return BadRequest();
            }

            _context.Entry(ventureLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureLocationExists(id))
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

        // POST: api/VentureLocations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VentureLocation>> PostVentureLocation(VentureLocation ventureLocation)
        {
            _context.VentureLocation.Add(ventureLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentureLocation", new { id = ventureLocation.VentureLocationId }, ventureLocation);
        }

        // DELETE: api/VentureLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VentureLocation>> DeleteVentureLocation(int id)
        {
            var ventureLocation = await _context.VentureLocation.FindAsync(id);
            if (ventureLocation == null)
            {
                return NotFound();
            }

            _context.VentureLocation.Remove(ventureLocation);
            await _context.SaveChangesAsync();

            return ventureLocation;
        }

        private bool VentureLocationExists(int id)
        {
            return _context.VentureLocation.Any(e => e.VentureLocationId == id);
        }
    }
}
