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
    public class VentureSchedulesController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public VentureSchedulesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/VentureSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureSchedule>>> GetVentureSchedule()
        {
            return await _context.VentureSchedule.ToListAsync();
        }

        // GET: api/VentureSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentureSchedule>> GetVentureSchedule(int id)
        {
            var ventureSchedule = await _context.VentureSchedule.FindAsync(id);

            if (ventureSchedule == null)
            {
                return NotFound();
            }

            return ventureSchedule;
        }

        // PUT: api/VentureSchedules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentureSchedule(int id, VentureSchedule ventureSchedule)
        {
            if (id != ventureSchedule.VentureScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(ventureSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureScheduleExists(id))
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

        // POST: api/VentureSchedules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VentureSchedule>> PostVentureSchedule(VentureSchedule ventureSchedule)
        {
            _context.VentureSchedule.Add(ventureSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentureSchedule", new { id = ventureSchedule.VentureScheduleId }, ventureSchedule);
        }

        // DELETE: api/VentureSchedules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VentureSchedule>> DeleteVentureSchedule(int id)
        {
            var ventureSchedule = await _context.VentureSchedule.FindAsync(id);
            if (ventureSchedule == null)
            {
                return NotFound();
            }

            _context.VentureSchedule.Remove(ventureSchedule);
            await _context.SaveChangesAsync();

            return ventureSchedule;
        }

        private bool VentureScheduleExists(int id)
        {
            return _context.VentureSchedule.Any(e => e.VentureScheduleId == id);
        }
    }
}
