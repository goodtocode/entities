using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Entities.WebApi1.Models;

namespace GoodToCode.Entities.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailTypesController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public DetailTypesController(EntityDataContext context)
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
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailType>> GetDetailType(int id)
        {
            var detailType = await _context.DetailType.FindAsync(id);

            if (detailType == null)
            {
                return NotFound();
            }

            return detailType;
        }

        // PUT: api/DetailTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailType(int id, DetailType detailType)
        {
            if (id != detailType.DetailTypeId)
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
                if (!DetailTypeExists(id))
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

            return CreatedAtAction("GetDetailType", new { id = detailType.DetailTypeId }, detailType);
        }

        // DELETE: api/DetailTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetailType>> DeleteDetailType(int id)
        {
            var detailType = await _context.DetailType.FindAsync(id);
            if (detailType == null)
            {
                return NotFound();
            }

            _context.DetailType.Remove(detailType);
            await _context.SaveChangesAsync();

            return detailType;
        }

        private bool DetailTypeExists(int id)
        {
            return _context.DetailType.Any(e => e.DetailTypeId == id);
        }
    }
}
