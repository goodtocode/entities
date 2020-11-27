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
    public class VentureOptionsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public VentureOptionsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/VentureOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureOption>>> GetVentureOption()
        {
            return await _dbContext.VentureOption.ToListAsync();
        }

        // GET: api/VentureOptions/5
        [HttpGet("{key}")]
        public async Task<ActionResult<VentureOption>> GetVentureOption(Guid key)
        {
            var ventureOption = await _dbContext.VentureOption.FindAsync(key);

            if (ventureOption == null)
            {
                return NotFound();
            }

            return ventureOption;
        }

        // PUT: api/VentureOptions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutVentureOption(Guid key, VentureOption ventureOption)
        {
            if (key != ventureOption.VentureOptionKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(ventureOption).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureOptionExists(key))
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
            _dbContext.VentureOption.Add(ventureOption);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetVentureOption", new { key = ventureOption.VentureOptionKey }, ventureOption);
        }

        // DELETE: api/VentureOptions/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<VentureOption>> DeleteVentureOption(Guid key)
        {
            var ventureOption = await _dbContext.VentureOption.FindAsync(key);
            if (ventureOption == null)
            {
                return NotFound();
            }

            _dbContext.VentureOption.Remove(ventureOption);
            await _dbContext.SaveChangesAsync();

            return ventureOption;
        }

        private bool VentureOptionExists(Guid key)
        {
            return _dbContext.VentureOption.Any(e => e.VentureOptionKey == key);
        }
    }
}
