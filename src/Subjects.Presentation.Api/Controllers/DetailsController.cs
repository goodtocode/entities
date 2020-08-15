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
        private readonly SubjectsDbContext _context;

        public DetailsController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detail>>> GetDetail()
        {
            return await _context.Detail.ToListAsync();
        }

        // GET: api/Details/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Detail>> GetDetail(Guid key)
        {
            var detail = await _context.Detail.FindAsync(key);

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

            _context.Entry(detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            _context.Detail.Add(detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetail", new { key = detail.DetailKey }, detail);
        }

        // DELETE: api/Details/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Detail>> DeleteDetail(Guid key)
        {
            var detail = await _context.Detail.FindAsync(key);
            if (detail == null)
            {
                return NotFound();
            }

            _context.Detail.Remove(detail);
            await _context.SaveChangesAsync();

            return detail;
        }

        private bool DetailExists(Guid key)
        {
            return _context.Detail.Any(e => e.DetailKey == key);
        }
    }
}
