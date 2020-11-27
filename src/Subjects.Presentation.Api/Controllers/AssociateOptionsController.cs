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
    public class AssociateOptionsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public AssociateOptionsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/AssociateOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateOption>>> GetAssociateOption()
        {
            return await _dbContext.AssociateOption.ToListAsync();
        }

        // GET: api/AssociateOptions/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateOption>> GetAssociateOption(Guid key)
        {
            var AssociateOption = await _dbContext.AssociateOption.FindAsync(key);

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

            _dbContext.Entry(AssociateOption).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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
            _dbContext.AssociateOption.Add(AssociateOption);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetAssociateOption", new { key = AssociateOption.AssociateOptionKey }, AssociateOption);
        }

        // DELETE: api/AssociateOptions/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateOption>> DeleteAssociateOption(Guid key)
        {
            var AssociateOption = await _dbContext.AssociateOption.FindAsync(key);
            if (AssociateOption == null)
            {
                return NotFound();
            }

            _dbContext.AssociateOption.Remove(AssociateOption);
            await _dbContext.SaveChangesAsync();

            return AssociateOption;
        }

        private bool AssociateOptionExists(Guid key)
        {
            return _dbContext.AssociateOption.Any(e => e.AssociateOptionKey == key);
        }
    }
}
