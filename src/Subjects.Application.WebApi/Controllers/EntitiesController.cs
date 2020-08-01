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
    public class EntitiesController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EntitiesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/Entities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entity>>> GetEntity()
        {
            return await _context.Entity.ToListAsync();
        }

        // GET: api/Entities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entity>> GetEntity(int id)
        {
            var entity = await _context.Entity.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Entities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntity(int id, Entity entity)
        {
            if (id != entity.EntityId)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
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

        // POST: api/Entities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Entity>> PostEntity(Entity entity)
        {
            _context.Entity.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntity", new { id = entity.EntityId }, entity);
        }

        // DELETE: api/Entities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entity>> DeleteEntity(int id)
        {
            var entity = await _context.Entity.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Entity.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        private bool EntityExists(int id)
        {
            return _context.Entity.Any(e => e.EntityId == id);
        }
    }
}
