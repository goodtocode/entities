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
    public class VentureDetailsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public VentureDetailsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/VentureDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureDetail>>> GetVentureDetail()
        {
            return await _context.VentureDetail.ToListAsync();
        }

        // GET: api/VentureDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentureDetail>> GetVentureDetail(int id)
        {
            var ventureDetail = await _context.VentureDetail.FindAsync(id);

            if (ventureDetail == null)
            {
                return NotFound();
            }

            return ventureDetail;
        }

        // PUT: api/VentureDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentureDetail(int id, VentureDetail ventureDetail)
        {
            if (id != ventureDetail.VentureDetailId)
            {
                return BadRequest();
            }

            _context.Entry(ventureDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureDetailExists(id))
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
            _context.VentureDetail.Add(ventureDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentureDetail", new { id = ventureDetail.VentureDetailId }, ventureDetail);
        }

        // DELETE: api/VentureDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VentureDetail>> DeleteVentureDetail(int id)
        {
            var ventureDetail = await _context.VentureDetail.FindAsync(id);
            if (ventureDetail == null)
            {
                return NotFound();
            }

            _context.VentureDetail.Remove(ventureDetail);
            await _context.SaveChangesAsync();

            return ventureDetail;
        }

        private bool VentureDetailExists(int id)
        {
            return _context.VentureDetail.Any(e => e.VentureDetailId == id);
        }
    }
}
