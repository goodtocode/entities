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
    public class VentureDetailsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public VentureDetailsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/VentureDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureDetail>>> GetVentureDetail()
        {
            return await _dbContext.VentureDetail.ToListAsync();
        }

        // GET: api/VentureDetails/5
        [HttpGet("{key}")]
        public async Task<ActionResult<VentureDetail>> GetVentureDetail(Guid key)
        {
            var ventureDetail = await _dbContext.VentureDetail.FindAsync(key);

            if (ventureDetail == null)
            {
                return NotFound();
            }

            return ventureDetail;
        }

        // PUT: api/VentureDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutVentureDetail(Guid key, VentureDetail ventureDetail)
        {
            if (key != ventureDetail.VentureDetailKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(ventureDetail).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureDetailExists(key))
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

        // POST: api/VentureDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VentureDetail>> PostVentureDetail(VentureDetail ventureDetail)
        {
            _dbContext.VentureDetail.Add(ventureDetail);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetVentureDetail", new { key = ventureDetail.VentureDetailKey }, ventureDetail);
        }

        // DELETE: api/VentureDetails/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<VentureDetail>> DeleteVentureDetail(Guid key)
        {
            var ventureDetail = await _dbContext.VentureDetail.FindAsync(key);
            if (ventureDetail == null)
            {
                return NotFound();
            }

            _dbContext.VentureDetail.Remove(ventureDetail);
            await _dbContext.SaveChangesAsync();

            return ventureDetail;
        }

        private bool VentureDetailExists(Guid key)
        {
            return _dbContext.VentureDetail.Any(e => e.VentureDetailKey == key);
        }
    }
}
