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
    public class ItemGroupsController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public ItemGroupsController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemGroup>>> GetItemGroup()
        {
            return await _context.ItemGroup.ToListAsync();
        }

        // GET: api/ItemGroups/5
        [HttpGet("{key}")]
        public async Task<ActionResult<ItemGroup>> GetItemGroup(Guid key)
        {
            var itemGroup = await _context.ItemGroup.FindAsync(key);

            if (itemGroup == null)
            {
                return NotFound();
            }

            return itemGroup;
        }

        // PUT: api/ItemGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutItemGroup(Guid key, ItemGroup itemGroup)
        {
            if (key != itemGroup.ItemGroupKey)
            {
                return BadRequest();
            }

            _context.Entry(itemGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemGroupExists(key))
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

        // POST: api/ItemGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemGroup>> PostItemGroup(ItemGroup itemGroup)
        {
            _context.ItemGroup.Add(itemGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemGroup", new { key = itemGroup.ItemGroupKey }, itemGroup);
        }

        // DELETE: api/ItemGroups/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<ItemGroup>> DeleteItemGroup(Guid key)
        {
            var itemGroup = await _context.ItemGroup.FindAsync(key);
            if (itemGroup == null)
            {
                return NotFound();
            }

            _context.ItemGroup.Remove(itemGroup);
            await _context.SaveChangesAsync();

            return itemGroup;
        }

        private bool ItemGroupExists(Guid key)
        {
            return _context.ItemGroup.Any(e => e.ItemGroupKey == key);
        }
    }
}
