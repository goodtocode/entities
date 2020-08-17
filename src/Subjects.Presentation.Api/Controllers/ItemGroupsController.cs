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
    public class ItemGroupsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public ItemGroupsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/ItemGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemGroup>>> GetItemGroup()
        {
            return await _dbContext.ItemGroup.ToListAsync();
        }

        // GET: api/ItemGroups/5
        [HttpGet("{key}")]
        public async Task<ActionResult<ItemGroup>> GetItemGroup(Guid key)
        {
            var itemGroup = await _dbContext.ItemGroup.FindAsync(key);

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

            _dbContext.Entry(itemGroup).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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
            _dbContext.ItemGroup.Add(itemGroup);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetItemGroup", new { key = itemGroup.ItemGroupKey }, itemGroup);
        }

        // DELETE: api/ItemGroups/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<ItemGroup>> DeleteItemGroup(Guid key)
        {
            var itemGroup = await _dbContext.ItemGroup.FindAsync(key);
            if (itemGroup == null)
            {
                return NotFound();
            }

            _dbContext.ItemGroup.Remove(itemGroup);
            await _dbContext.SaveChangesAsync();

            return itemGroup;
        }

        private bool ItemGroupExists(Guid key)
        {
            return _dbContext.ItemGroup.Any(e => e.ItemGroupKey == key);
        }
    }
}
