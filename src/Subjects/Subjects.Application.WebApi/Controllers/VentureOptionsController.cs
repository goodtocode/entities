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
    public class VentureOptionsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public VentureOptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/VentureOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureOption>>> GetVentureOption()
        {
            return await _context.VentureOption.ToListAsync();
        }

        // GET: api/VentureOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentureOption>> GetVentureOption(int id)
        {
            var ventureOption = await _context.VentureOption.FindAsync(id);

            if (ventureOption == null)
            {
                return NotFound();
            }

            return ventureOption;
        }

        // PUT: api/VentureOptions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentureOption(int id, VentureOption ventureOption)
        {
            if (id != ventureOption.VentureOptionId)
            {
                return BadRequest();
            }

            _context.Entry(ventureOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureOptionExists(id))
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

        // POST: api/VentureOptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VentureOption>> PostVentureOption(VentureOption ventureOption)
        {
            _context.VentureOption.Add(ventureOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentureOption", new { id = ventureOption.VentureOptionId }, ventureOption);
        }

        // DELETE: api/VentureOptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VentureOption>> DeleteVentureOption(int id)
        {
            var ventureOption = await _context.VentureOption.FindAsync(id);
            if (ventureOption == null)
            {
                return NotFound();
            }

            _context.VentureOption.Remove(ventureOption);
            await _context.SaveChangesAsync();

            return ventureOption;
        }

        private bool VentureOptionExists(int id)
        {
            return _context.VentureOption.Any(e => e.VentureOptionId == id);
        }
    }
}
