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
    public class ItemGroupsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public ItemGroupsController(EntityDataContext context)
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
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemGroup>> GetItemGroup(int id)
        {
            var itemGroup = await _context.ItemGroup.FindAsync(id);

            if (itemGroup == null)
            {
                return NotFound();
            }

            return itemGroup;
        }

        // PUT: api/ItemGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemGroup(int id, ItemGroup itemGroup)
        {
            if (id != itemGroup.ItemGroupId)
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
                if (!ItemGroupExists(id))
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

            return CreatedAtAction("GetItemGroup", new { id = itemGroup.ItemGroupId }, itemGroup);
        }

        // DELETE: api/ItemGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemGroup>> DeleteItemGroup(int id)
        {
            var itemGroup = await _context.ItemGroup.FindAsync(id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            _context.ItemGroup.Remove(itemGroup);
            await _context.SaveChangesAsync();

            return itemGroup;
        }

        private bool ItemGroupExists(int id)
        {
            return _context.ItemGroup.Any(e => e.ItemGroupId == id);
        }
    }
}
