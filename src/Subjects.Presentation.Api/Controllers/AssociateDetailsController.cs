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
    public class AssociateDetailsController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public AssociateDetailsController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/AssociateDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateDetail>>> GetAssociateDetail()
        {
            return await _context.AssociateDetail.ToListAsync();
        }

        // GET: api/AssociateDetails/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateDetail>> GetAssociateDetail(Guid key)
        {
            var AssociateDetail = await _context.AssociateDetail.FindAsync(key);

            if (AssociateDetail == null)
            {
                return NotFound();
            }

            return AssociateDetail;
        }

        // PUT: api/AssociateDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutAssociateDetail(Guid key, AssociateDetail AssociateDetail)
        {
            if (key != AssociateDetail.AssociateDetailKey)
            {
                return BadRequest();
            }

            _context.Entry(AssociateDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociateDetailExists(key))
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

        // POST: api/AssociateDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssociateDetail>> PostAssociateDetail(AssociateDetail AssociateDetail)
        {
            _context.AssociateDetail.Add(AssociateDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssociateDetail", new { key = AssociateDetail.AssociateDetailKey }, AssociateDetail);
        }

        // DELETE: api/AssociateDetails/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateDetail>> DeleteAssociateDetail(Guid key)
        {
            var AssociateDetail = await _context.AssociateDetail.FindAsync(key);
            if (AssociateDetail == null)
            {
                return NotFound();
            }

            _context.AssociateDetail.Remove(AssociateDetail);
            await _context.SaveChangesAsync();

            return AssociateDetail;
        }

        private bool AssociateDetailExists(Guid key)
        {
            return _context.AssociateDetail.Any(e => e.AssociateDetailKey == key);
        }
    }
}
