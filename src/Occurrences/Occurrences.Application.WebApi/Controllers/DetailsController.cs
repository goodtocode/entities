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
    public class DetailsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public DetailsController(EntityDataContext context)
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Detail>> GetDetail(int id)
        {
            var detail = await _context.Detail.FindAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            return detail;
        }

        // PUT: api/Details/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetail(int id, Detail detail)
        {
            if (id != detail.DetailId)
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
                if (!DetailExists(id))
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

            return CreatedAtAction("GetDetail", new { id = detail.DetailId }, detail);
        }

        // DELETE: api/Details/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detail>> DeleteDetail(int id)
        {
            var detail = await _context.Detail.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            _context.Detail.Remove(detail);
            await _context.SaveChangesAsync();

            return detail;
        }

        private bool DetailExists(int id)
        {
            return _context.Detail.Any(e => e.DetailId == id);
        }
    }
}
