using GoodToCode.Subjects.Infrastructure;
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
        private readonly SubjectsDbContext _dbContext;

        public VenturesController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/Ventures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venture>>> GetVenture()
        {
            return await _dbContext.Venture.ToListAsync();
        }

        // GET: api/Ventures/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Venture>> GetVenture(Guid key)
        {
            var venture = await _dbContext.Venture.FindAsync(key);

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

            _dbContext.Entry(venture).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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
            _dbContext.Venture.Add(venture);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetVenture", new { key = venture.VentureKey }, venture);
        }

        // DELETE: api/Ventures/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Venture>> DeleteVenture(Guid key)
        {
            var venture = await _dbContext.Venture.FindAsync(key);
            if (venture == null)
            {
                return NotFound();
            }

            _dbContext.Venture.Remove(venture);
            await _dbContext.SaveChangesAsync();

            return venture;
        }

        private bool VentureExists(Guid key)
        {
            return _dbContext.Venture.Any(e => e.VentureKey == key);
        }
    }
}
