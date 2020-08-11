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
    public class VentureSchedulesController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public VentureSchedulesController(SubjectsDbContext context)
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
        [HttpGet("{key}")]
        public async Task<ActionResult<VentureSchedule>> GetVentureSchedule(Guid key)
        {
            var ventureSchedule = await _context.VentureSchedule.FindAsync(key);

            if (ventureSchedule == null)
            {
                return NotFound();
            }

            return ventureSchedule;
        }

        // PUT: api/VentureSchedules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutVentureSchedule(Guid key, VentureSchedule ventureSchedule)
        {
            if (key != ventureSchedule.VentureScheduleKey)
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
                if (!VentureScheduleExists(key))
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

            return CreatedAtAction("GetVentureSchedule", new { key = ventureSchedule.VentureScheduleKey }, ventureSchedule);
        }

        // DELETE: api/VentureSchedules/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<VentureSchedule>> DeleteVentureSchedule(Guid key)
        {
            var ventureSchedule = await _context.VentureSchedule.FindAsync(key);
            if (ventureSchedule == null)
            {
                return NotFound();
            }

            _context.VentureSchedule.Remove(ventureSchedule);
            await _context.SaveChangesAsync();

            return ventureSchedule;
        }

        private bool VentureScheduleExists(Guid key)
        {
            return _context.VentureSchedule.Any(e => e.VentureScheduleKey == key);
        }
    }
}
