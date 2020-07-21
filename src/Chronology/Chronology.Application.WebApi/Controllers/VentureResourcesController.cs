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
    public class VentureResourcesController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public VentureResourcesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/VentureResources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureResource>>> GetVentureResource()
        {
            return await _context.VentureResource.ToListAsync();
        }

        // GET: api/VentureResources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentureResource>> GetVentureResource(int id)
        {
            var ventureResource = await _context.VentureResource.FindAsync(id);

            if (ventureResource == null)
            {
                return NotFound();
            }

            return ventureResource;
        }

        // PUT: api/VentureResources/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentureResource(int id, VentureResource ventureResource)
        {
            if (id != ventureResource.VentureResourceId)
            {
                return BadRequest();
            }

            _context.Entry(ventureResource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureResourceExists(id))
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

        // POST: api/VentureResources
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VentureResource>> PostVentureResource(VentureResource ventureResource)
        {
            _context.VentureResource.Add(ventureResource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentureResource", new { id = ventureResource.VentureResourceId }, ventureResource);
        }

        // DELETE: api/VentureResources/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VentureResource>> DeleteVentureResource(int id)
        {
            var ventureResource = await _context.VentureResource.FindAsync(id);
            if (ventureResource == null)
            {
                return NotFound();
            }

            _context.VentureResource.Remove(ventureResource);
            await _context.SaveChangesAsync();

            return ventureResource;
        }

        private bool VentureResourceExists(int id)
        {
            return _context.VentureResource.Any(e => e.VentureResourceId == id);
        }
    }
}
