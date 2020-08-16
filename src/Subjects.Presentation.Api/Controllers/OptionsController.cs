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
    public class OptionsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public OptionsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/Options
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option>>> GetOption()
        {
            return await _dbContext.Option.ToListAsync();
        }

        // GET: api/Options/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Option>> GetOption(Guid key)
        {
            var option = await _dbContext.Option.FindAsync(key);

            if (option == null)
            {
                return NotFound();
            }

            return option;
        }

        // PUT: api/Options/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutOption(Guid key, Option option)
        {
            if (key != option.OptionKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(option).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(key))
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

        // POST: api/Options
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Option>> PostOption(Option option)
        {
            _dbContext.Option.Add(option);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetOption", new { key = option.OptionKey }, option);
        }

        // DELETE: api/Options/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Option>> DeleteOption(Guid key)
        {
            var option = await _dbContext.Option.FindAsync(key);
            if (option == null)
            {
                return NotFound();
            }

            _dbContext.Option.Remove(option);
            await _dbContext.SaveChangesAsync();

            return option;
        }

        private bool OptionExists(Guid key)
        {
            return _dbContext.Option.Any(e => e.OptionKey == key);
        }
    }
}
