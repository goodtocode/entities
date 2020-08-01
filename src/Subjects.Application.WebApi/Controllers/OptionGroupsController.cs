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
    public class OptionGroupsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public OptionGroupsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/OptionGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionGroup>>> GetOptionGroup()
        {
            return await _context.OptionGroup.ToListAsync();
        }

        // GET: api/OptionGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionGroup>> GetOptionGroup(int id)
        {
            var optionGroup = await _context.OptionGroup.FindAsync(id);

            if (optionGroup == null)
            {
                return NotFound();
            }

            return optionGroup;
        }

        // PUT: api/OptionGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptionGroup(int id, OptionGroup optionGroup)
        {
            if (id != optionGroup.OptionGroupId)
            {
                return BadRequest();
            }

            _context.Entry(optionGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionGroupExists(id))
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
            _context.OptionGroup.Add(optionGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOptionGroup", new { id = optionGroup.OptionGroupId }, optionGroup);
        }

        // DELETE: api/OptionGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OptionGroup>> DeleteOptionGroup(int id)
        {
            var optionGroup = await _context.OptionGroup.FindAsync(id);
            if (optionGroup == null)
            {
                return NotFound();
            }

            _context.OptionGroup.Remove(optionGroup);
            await _context.SaveChangesAsync();

            return optionGroup;
        }

        private bool OptionGroupExists(int id)
        {
            return _context.OptionGroup.Any(e => e.OptionGroupId == id);
        }
    }
}
