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
    public class ResourcesController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public ResourcesController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/Resources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResource()
        {
            return await _dbContext.Resource.ToListAsync();
        }

        // GET: api/Resources/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Resource>> GetResource(Guid key)
        {
            var resource = await _dbContext.Resource.FindAsync(key);

            if (resource == null)
            {
                return NotFound();
            }

            return resource;
        }

        // PUT: api/Resources/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutResource(Guid key, Resource resource)
        {
            if (key != resource.ResourceKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(resource).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceExists(key))
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

        // POST: api/Resources
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Resource>> PostResource(Resource resource)
        {
            _dbContext.Resource.Add(resource);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetResource", new { key = resource.ResourceKey }, resource);
        }

        // DELETE: api/Resources/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Resource>> DeleteResource(Guid key)
        {
            var resource = await _dbContext.Resource.FindAsync(key);
            if (resource == null)
            {
                return NotFound();
            }

            _dbContext.Resource.Remove(resource);
            await _dbContext.SaveChangesAsync();

            return resource;
        }

        private bool ResourceExists(Guid key)
        {
            return _dbContext.Resource.Any(e => e.ResourceKey == key);
        }
    }
}
