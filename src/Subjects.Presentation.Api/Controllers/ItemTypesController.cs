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
    public class ItemTypesController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public ItemTypesController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/ItemTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemType>>> GetItemType()
        {
            return await _dbContext.ItemType.ToListAsync();
        }

        // GET: api/ItemTypes/5
        [HttpGet("{key}")]
        public async Task<ActionResult<ItemType>> GetItemType(Guid key)
        {
            var itemType = await _dbContext.ItemType.FindAsync(key);

            if (itemType == null)
            {
                return NotFound();
            }

            return itemType;
        }

        // PUT: api/ItemTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutItemType(Guid key, ItemType itemType)
        {
            if (key != itemType.ItemTypeKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(itemType).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTypeExists(key))
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

        // POST: api/ItemTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemType>> PostItemType(ItemType itemType)
        {
            _dbContext.ItemType.Add(itemType);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetItemType", new { key = itemType.ItemTypeKey }, itemType);
        }

        // DELETE: api/ItemTypes/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<ItemType>> DeleteItemType(Guid key)
        {
            var itemType = await _dbContext.ItemType.FindAsync(key);
            if (itemType == null)
            {
                return NotFound();
            }

            _dbContext.ItemType.Remove(itemType);
            await _dbContext.SaveChangesAsync();

            return itemType;
        }

        private bool ItemTypeExists(Guid key)
        {
            return _dbContext.ItemType.Any(e => e.ItemTypeKey == key);
        }
    }
}
