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
    public class ItemsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public ItemsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
            return await _dbContext.Item.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Item>> GetItem(Guid key)
        {
            var item = await _dbContext.Item.FindAsync(key);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutItem(Guid key, Item item)
        {
            if (key != item.ItemKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(item).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(key))
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

        // POST: api/Items
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _dbContext.Item.Add(item);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { key = item.ItemKey }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Item>> DeleteItem(Guid key)
        {
            var item = await _dbContext.Item.FindAsync(key);
            if (item == null)
            {
                return NotFound();
            }

            _dbContext.Item.Remove(item);
            await _dbContext.SaveChangesAsync();

            return item;
        }

        private bool ItemExists(Guid key)
        {
            return _dbContext.Item.Any(e => e.ItemKey == key);
        }
    }
}
