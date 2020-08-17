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
    public class DetailsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public DetailsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detail>>> GetDetail()
        {
            return await _dbContext.Detail.ToListAsync();
        }

        // GET: api/Details/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Detail>> GetDetail(Guid key)
        {
            var detail = await _dbContext.Detail.FindAsync(key);

            if (detail == null)
            {
                return NotFound();
            }

            return detail;
        }

        // PUT: api/Details/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutDetail(Guid key, Detail detail)
        {
            if (key != detail.DetailKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(detail).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExists(key))
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

        // POST: api/Details
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Detail>> PostDetail(Detail detail)
        {
            _dbContext.Detail.Add(detail);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetDetail", new { key = detail.DetailKey }, detail);
        }

        // DELETE: api/Details/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Detail>> DeleteDetail(Guid key)
        {
            var detail = await _dbContext.Detail.FindAsync(key);
            if (detail == null)
            {
                return NotFound();
            }

            _dbContext.Detail.Remove(detail);
            await _dbContext.SaveChangesAsync();

            return detail;
        }

        private bool DetailExists(Guid key)
        {
            return _dbContext.Detail.Any(e => e.DetailKey == key);
        }
    }
}
