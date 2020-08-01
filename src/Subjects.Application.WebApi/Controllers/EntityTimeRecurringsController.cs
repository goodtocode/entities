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
    public class EntityTimeRecurringsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EntityTimeRecurringsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/EntityTimeRecurrings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityTimeRecurring>>> GetEntityTimeRecurring()
        {
            return await _context.EntityTimeRecurring.ToListAsync();
        }

        // GET: api/EntityTimeRecurrings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityTimeRecurring>> GetEntityTimeRecurring(int id)
        {
            var entityTimeRecurring = await _context.EntityTimeRecurring.FindAsync(id);

            if (entityTimeRecurring == null)
            {
                return NotFound();
            }

            return entityTimeRecurring;
        }

        // PUT: api/EntityTimeRecurrings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityTimeRecurring(int id, EntityTimeRecurring entityTimeRecurring)
        {
            if (id != entityTimeRecurring.EntityTimeRecurringId)
            {
                return BadRequest();
            }

            _context.Entry(entityTimeRecurring).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityTimeRecurringExists(id))
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

        // POST: api/EntityTimeRecurrings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EntityTimeRecurring>> PostEntityTimeRecurring(EntityTimeRecurring entityTimeRecurring)
        {
            _context.EntityTimeRecurring.Add(entityTimeRecurring);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityTimeRecurring", new { id = entityTimeRecurring.EntityTimeRecurringId }, entityTimeRecurring);
        }

        // DELETE: api/EntityTimeRecurrings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EntityTimeRecurring>> DeleteEntityTimeRecurring(int id)
        {
            var entityTimeRecurring = await _context.EntityTimeRecurring.FindAsync(id);
            if (entityTimeRecurring == null)
            {
                return NotFound();
            }

            _context.EntityTimeRecurring.Remove(entityTimeRecurring);
            await _context.SaveChangesAsync();

            return entityTimeRecurring;
        }

        private bool EntityTimeRecurringExists(int id)
        {
            return _context.EntityTimeRecurring.Any(e => e.EntityTimeRecurringId == id);
        }
    }
}
