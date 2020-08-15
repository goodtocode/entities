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
    public class VenturesController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public VenturesController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/Ventures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venture>>> GetVenture()
        {
            return await _context.Venture.ToListAsync();
        }

        // GET: api/Ventures/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Venture>> GetVenture(Guid key)
        {
            var venture = await _context.Venture.FindAsync(key);

            if (venture == null)
            {
                return NotFound();
            }

            return venture;
        }

        // PUT: api/Ventures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutVenture(Guid key, Venture venture)
        {
            if (key != venture.VentureKey)
            {
                return BadRequest();
            }

            _context.Entry(venture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureExists(key))
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

        // POST: api/Ventures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Venture>> PostVenture(Venture venture)
        {
            _context.Venture.Add(venture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenture", new { key = venture.VentureKey }, venture);
        }

        // DELETE: api/Ventures/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Venture>> DeleteVenture(Guid key)
        {
            var venture = await _context.Venture.FindAsync(key);
            if (venture == null)
            {
                return NotFound();
            }

            _context.Venture.Remove(venture);
            await _context.SaveChangesAsync();

            return venture;
        }

        private bool VentureExists(Guid key)
        {
            return _context.Venture.Any(e => e.VentureKey == key);
        }
    }
}
