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
    public class AssociatesController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public AssociatesController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/Entities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Associate>>> GetEntity()
        {
            return await _dbContext.Associate.ToListAsync();
        }

        // GET: api/Entities/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Associate>> GetEntity(Guid key)
        {
            var entity = await _dbContext.Associate.FindAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Entities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutEntity(Guid key, Associate entity)
        {
            if (key != entity.AssociateKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(entity).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(key))
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
        public async Task<ActionResult<Associate>> PostEntity(Associate entity)
        {
            _dbContext.Associate.Add(entity);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetEntity", new { key = entity.AssociateKey }, entity);
        }

        // DELETE: api/Entities/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Associate>> DeleteEntity(Guid key)
        {
            var entity = await _dbContext.Associate.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _dbContext.Associate.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        private bool EntityExists(Guid key)
        {
            return _dbContext.Associate.Any(e => e.AssociateKey == key);
        }
    }
}
