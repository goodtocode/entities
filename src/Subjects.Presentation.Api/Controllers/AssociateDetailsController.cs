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
    public class AssociateDetailsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public AssociateDetailsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/AssociateDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateDetail>>> GetAssociateDetail()
        {
            return await _dbContext.AssociateDetail.ToListAsync();
        }

        // GET: api/AssociateDetails/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateDetail>> GetAssociateDetail(Guid key)
        {
            var AssociateDetail = await _dbContext.AssociateDetail.FindAsync(key);

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

            _dbContext.Entry(AssociateDetail).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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
            _dbContext.AssociateDetail.Add(AssociateDetail);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetAssociateDetail", new { key = AssociateDetail.AssociateDetailKey }, AssociateDetail);
        }

        // DELETE: api/AssociateDetails/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateDetail>> DeleteAssociateDetail(Guid key)
        {
            var AssociateDetail = await _dbContext.AssociateDetail.FindAsync(key);
            if (AssociateDetail == null)
            {
                return NotFound();
            }

            _dbContext.AssociateDetail.Remove(AssociateDetail);
            await _dbContext.SaveChangesAsync();

            return AssociateDetail;
        }

        private bool AssociateDetailExists(Guid key)
        {
            return _dbContext.AssociateDetail.Any(e => e.AssociateDetailKey == key);
        }
    }
}
