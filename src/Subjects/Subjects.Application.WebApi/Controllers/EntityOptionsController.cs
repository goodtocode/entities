using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Subjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityOptionsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EntityOptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/EntityOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityOption>>> GetEntityOption()
        {
            return await _context.EntityOption.ToListAsync();
        }

        // GET: api/EntityOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityOption>> GetEntityOption(int id)
        {
            var entityOption = await _context.EntityOption.FindAsync(id);

            if (entityOption == null)
            {
                return NotFound();
            }

            return entityOption;
        }

        // PUT: api/EntityOptions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityOption(int id, EntityOption entityOption)
        {
            if (id != entityOption.EntityOptionId)
            {
                return BadRequest();
            }

            _context.Entry(entityOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityOptionExists(id))
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

        // POST: api/EntityOptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EntityOption>> PostEntityOption(EntityOption entityOption)
        {
            _context.EntityOption.Add(entityOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityOption", new { id = entityOption.EntityOptionId }, entityOption);
        }

        // DELETE: api/EntityOptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EntityOption>> DeleteEntityOption(int id)
        {
            var entityOption = await _context.EntityOption.FindAsync(id);
            if (entityOption == null)
            {
                return NotFound();
            }

            _context.EntityOption.Remove(entityOption);
            await _context.SaveChangesAsync();

            return entityOption;
        }

        private bool EntityOptionExists(int id)
        {
            return _context.EntityOption.Any(e => e.EntityOptionId == id);
        }
    }
}
