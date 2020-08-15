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
        private readonly SubjectsDbContext _context;

        public ItemTypesController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemType>>> GetItemType()
        {
            return await _context.ItemType.ToListAsync();
        }

        // GET: api/ItemTypes/5
        [HttpGet("{key}")]
        public async Task<ActionResult<ItemType>> GetItemType(Guid key)
        {
            var itemType = await _context.ItemType.FindAsync(key);

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

            _context.Entry(itemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            _context.ItemType.Add(itemType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemType", new { key = itemType.ItemTypeKey }, itemType);
        }

        // DELETE: api/ItemTypes/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<ItemType>> DeleteItemType(Guid key)
        {
            var itemType = await _context.ItemType.FindAsync(key);
            if (itemType == null)
            {
                return NotFound();
            }

            _context.ItemType.Remove(itemType);
            await _context.SaveChangesAsync();

            return itemType;
        }

        private bool ItemTypeExists(Guid key)
        {
            return _context.ItemType.Any(e => e.ItemTypeKey == key);
        }
    }
}
