using GoodToCode.Locality.Infrastructure;
using GoodToCode.Locality.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Locality.Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentureLocationsController : ControllerBase
    {
        private readonly LocalityDbContext _dbContext;

        public VentureLocationsController(LocalityDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/VentureLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureLocation>>> GetVentureLocation()
        {
            return await _dbContext.VentureLocation.ToListAsync();
        }

        // GET: api/VentureLocations/5
        [HttpGet("{key}")]
        public async Task<ActionResult<VentureLocation>> GetVentureLocation(Guid key)
        {
            var ventureLocation = await _dbContext.VentureLocation.FindAsync(key);

            if (ventureLocation == null)
            {
                return NotFound();
            }

            return ventureLocation;
        }

        // PUT: api/VentureLocations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutVentureLocation(Guid key, VentureLocation ventureLocation)
        {
            if (key != ventureLocation.VentureLocationKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(ventureLocation).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureLocationExists(key))
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
            _dbContext.VentureLocation.Add(ventureLocation);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetVentureLocation", new { key = ventureLocation.VentureLocationKey }, ventureLocation);
        }

        // DELETE: api/VentureLocations/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<VentureLocation>> DeleteVentureLocation(Guid key)
        {
            var ventureLocation = await _dbContext.VentureLocation.FindAsync(key);
            if (ventureLocation == null)
            {
                return NotFound();
            }

            _dbContext.VentureLocation.Remove(ventureLocation);
            await _dbContext.SaveChangesAsync();

            return ventureLocation;
        }

        private bool VentureLocationExists(Guid key)
        {
            return _dbContext.VentureLocation.Any(e => e.VentureLocationKey == key);
        }
    }
}
