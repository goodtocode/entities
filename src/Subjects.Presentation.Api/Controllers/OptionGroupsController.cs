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
    public class OptionGroupsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public OptionGroupsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/OptionGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionGroup>>> GetOptionGroup()
        {
            return await _dbContext.OptionGroup.ToListAsync();
        }

        // GET: api/OptionGroups/5
        [HttpGet("{key}")]
        public async Task<ActionResult<OptionGroup>> GetOptionGroup(Guid key)
        {
            var optionGroup = await _dbContext.OptionGroup.FindAsync(key);

            if (optionGroup == null)
            {
                return NotFound();
            }

            return optionGroup;
        }

        // PUT: api/OptionGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutOptionGroup(Guid key, OptionGroup optionGroup)
        {
            if (key != optionGroup.OptionGroupKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(optionGroup).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionGroupExists(key))
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

        // POST: api/OptionGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OptionGroup>> PostOptionGroup(OptionGroup optionGroup)
        {
            _dbContext.OptionGroup.Add(optionGroup);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetOptionGroup", new { key = optionGroup.OptionGroupKey }, optionGroup);
        }

        // DELETE: api/OptionGroups/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<OptionGroup>> DeleteOptionGroup(Guid key)
        {
            var optionGroup = await _dbContext.OptionGroup.FindAsync(key);
            if (optionGroup == null)
            {
                return NotFound();
            }

            _dbContext.OptionGroup.Remove(optionGroup);
            await _dbContext.SaveChangesAsync();

            return optionGroup;
        }

        private bool OptionGroupExists(Guid key)
        {
            return _dbContext.OptionGroup.Any(e => e.OptionGroupKey == key);
        }
    }
}
