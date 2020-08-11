using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailTypesController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public DetailTypesController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/DetailTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailType>>> GetDetailType()
        {
            return await _context.DetailType.ToListAsync();
        }

        // GET: api/DetailTypes/5
        [HttpGet("{key}")]
        public async Task<ActionResult<DetailType>> GetDetailType(Guid key)
        {
            var detailType = await _context.DetailType.FindAsync(key);

            if (detailType == null)
            {
                return NotFound();
            }

            return detailType;
        }

        // PUT: api/DetailTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutDetailType(Guid key, DetailType detailType)
        {
            if (key != detailType.DetailTypeKey)
            {
                return BadRequest();
            }

            _context.Entry(detailType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailTypeExists(key))
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

        // POST: api/DetailTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetailType>> PostDetailType(DetailType detailType)
        {   
            _context.DetailType.Add(detailType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailType", new { key = detailType.DetailTypeKey }, detailType);
        }

        // DELETE: api/DetailTypes/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<DetailType>> DeleteDetailType(Guid key)
        {
            var detailType = await _context.DetailType.FindAsync(key);
            if (detailType == null)
            {
                return NotFound();
            }

            _context.DetailType.Remove(detailType);
            await _context.SaveChangesAsync();

            return detailType;
        }

        private bool DetailTypeExists(Guid key)
        {
            return _context.DetailType.Any(e => e.DetailTypeKey == key);
        }
    }
}
