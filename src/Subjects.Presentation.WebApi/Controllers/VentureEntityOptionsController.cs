using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Shared.Models;

namespace GoodToCode.Subjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentureEntityOptionsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public VentureEntityOptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/VentureEntityOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureEntityOption>>> GetVentureEntityOption()
        {
            return await _context.VentureEntityOption.ToListAsync();
        }

        // GET: api/VentureEntityOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentureEntityOption>> GetVentureEntityOption(int id)
        {
            var ventureEntityOption = await _context.VentureEntityOption.FindAsync(id);

            if (ventureEntityOption == null)
            {
                return NotFound();
            }

            return ventureEntityOption;
        }

        // PUT: api/VentureEntityOptions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentureEntityOption(int id, VentureEntityOption ventureEntityOption)
        {
            if (id != ventureEntityOption.VentureEntityOptionId)
            {
                return BadRequest();
            }

            _context.Entry(ventureEntityOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureEntityOptionExists(id))
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

        // POST: api/VentureEntityOptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VentureEntityOption>> PostVentureEntityOption(VentureEntityOption ventureEntityOption)
        {
            _context.VentureEntityOption.Add(ventureEntityOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentureEntityOption", new { id = ventureEntityOption.VentureEntityOptionId }, ventureEntityOption);
        }

        // DELETE: api/VentureEntityOptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VentureEntityOption>> DeleteVentureEntityOption(int id)
        {
            var ventureEntityOption = await _context.VentureEntityOption.FindAsync(id);
            if (ventureEntityOption == null)
            {
                return NotFound();
            }

            _context.VentureEntityOption.Remove(ventureEntityOption);
            await _context.SaveChangesAsync();

            return ventureEntityOption;
        }

        private bool VentureEntityOptionExists(int id)
        {
            return _context.VentureEntityOption.Any(e => e.VentureEntityOptionId == id);
        }
    }
}
