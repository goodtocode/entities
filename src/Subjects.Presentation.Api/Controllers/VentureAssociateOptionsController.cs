using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentureAssociateOptionsController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public VentureAssociateOptionsController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/VentureAssociateOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureAssociateOption>>> GetVentureAssociateOption()
        {
            return await _context.VentureAssociateOption.ToListAsync();
        }

        // GET: api/VentureAssociateOptions/5
        [HttpGet("{key}")]
        public async Task<ActionResult<VentureAssociateOption>> GetVentureAssociateOption(Guid key)
        {
            var ventureAssociateOption = await _context.VentureAssociateOption.FindAsync(key);

            if (ventureAssociateOption == null)
            {
                return NotFound();
            }

            return ventureAssociateOption;
        }

        // PUT: api/VentureAssociateOptions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutVentureAssociateOption(Guid key, VentureAssociateOption ventureAssociateOption)
        {
            if (key != ventureAssociateOption.VentureAssociateOptionKey)
            {
                return BadRequest();
            }

            _context.Entry(ventureAssociateOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureAssociateOptionExists(key))
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

        // POST: api/VentureAssociateOptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VentureAssociateOption>> PostVentureAssociateOption(VentureAssociateOption ventureAssociateOption)
        {
            _context.VentureAssociateOption.Add(ventureAssociateOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentureAssociateOption", new { key = ventureAssociateOption.VentureAssociateOptionKey }, ventureAssociateOption);
        }

        // DELETE: api/VentureAssociateOptions/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<VentureAssociateOption>> DeleteVentureAssociateOption(Guid key)
        {
            var ventureAssociateOption = await _context.VentureAssociateOption.FindAsync(key);
            if (ventureAssociateOption == null)
            {
                return NotFound();
            }

            _context.VentureAssociateOption.Remove(ventureAssociateOption);
            await _context.SaveChangesAsync();

            return ventureAssociateOption;
        }

        private bool VentureAssociateOptionExists(Guid key)
        {
            return _context.VentureAssociateOption.Any(e => e.VentureAssociateOptionKey == key);
        }
    }
}
