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
    public class AssociateOptionsController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public AssociateOptionsController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/AssociateOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateOption>>> GetAssociateOption()
        {
            return await _context.AssociateOption.ToListAsync();
        }

        // GET: api/AssociateOptions/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateOption>> GetAssociateOption(Guid key)
        {
            var AssociateOption = await _context.AssociateOption.FindAsync(key);

            if (AssociateOption == null)
            {
                return NotFound();
            }

            return AssociateOption;
        }

        // PUT: api/AssociateOptions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutAssociateOption(Guid key, AssociateOption AssociateOption)
        {
            if (key != AssociateOption.AssociateOptionKey)
            {
                return BadRequest();
            }

            _context.Entry(AssociateOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociateOptionExists(key))
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

        // POST: api/AssociateOptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssociateOption>> PostAssociateOption(AssociateOption AssociateOption)
        {
            _context.AssociateOption.Add(AssociateOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssociateOption", new { key = AssociateOption.AssociateOptionKey }, AssociateOption);
        }

        // DELETE: api/AssociateOptions/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateOption>> DeleteAssociateOption(Guid key)
        {
            var AssociateOption = await _context.AssociateOption.FindAsync(key);
            if (AssociateOption == null)
            {
                return NotFound();
            }

            _context.AssociateOption.Remove(AssociateOption);
            await _context.SaveChangesAsync();

            return AssociateOption;
        }

        private bool AssociateOptionExists(Guid key)
        {
            return _context.AssociateOption.Any(e => e.AssociateOptionKey == key);
        }
    }
}
