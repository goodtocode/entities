using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Subjects.Application.Models;

namespace GoodToCode.Subjects.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenturesController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public VenturesController(EntityDataContext context)
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Venture>> GetVenture(int id)
        {
            var venture = await _context.Venture.FindAsync(id);

            if (venture == null)
            {
                return NotFound();
            }

            return venture;
        }

        // PUT: api/Ventures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenture(int id, Venture venture)
        {
            if (id != venture.VentureId)
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
                if (!VentureExists(id))
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

            return CreatedAtAction("GetVenture", new { id = venture.VentureId }, venture);
        }

        // DELETE: api/Ventures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Venture>> DeleteVenture(int id)
        {
            var venture = await _context.Venture.FindAsync(id);
            if (venture == null)
            {
                return NotFound();
            }

            _context.Venture.Remove(venture);
            await _context.SaveChangesAsync();

            return venture;
        }

        private bool VentureExists(int id)
        {
            return _context.Venture.Any(e => e.VentureId == id);
        }
    }
}
