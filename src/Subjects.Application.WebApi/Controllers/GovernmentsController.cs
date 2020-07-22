using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Shared.Models;

namespace GoodToCode.Subjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public GovernmentsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/Governments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Government>>> GetGovernment()
        {
            return await _context.Government.ToListAsync();
        }

        // GET: api/Governments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Government>> GetGovernment(int id)
        {
            var government = await _context.Government.FindAsync(id);

            if (government == null)
            {
                return NotFound();
            }

            return government;
        }

        // PUT: api/Governments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGovernment(int id, Government government)
        {
            if (id != government.GovernmentId)
            {
                return BadRequest();
            }

            _context.Entry(government).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GovernmentExists(id))
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

        // POST: api/Governments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Government>> PostGovernment(Government government)
        {
            _context.Government.Add(government);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGovernment", new { id = government.GovernmentId }, government);
        }

        // DELETE: api/Governments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Government>> DeleteGovernment(int id)
        {
            var government = await _context.Government.FindAsync(id);
            if (government == null)
            {
                return NotFound();
            }

            _context.Government.Remove(government);
            await _context.SaveChangesAsync();

            return government;
        }

        private bool GovernmentExists(int id)
        {
            return _context.Government.Any(e => e.GovernmentId == id);
        }
    }
}
