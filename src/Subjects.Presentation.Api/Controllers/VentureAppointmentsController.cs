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
    public class VentureAppointmentsController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public VentureAppointmentsController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/VentureAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureAppointment>>> GetVentureAppointment()
        {
            return await _dbContext.VentureAppointment.ToListAsync();
        }

        // GET: api/VentureAppointments/5
        [HttpGet("{key}")]
        public async Task<ActionResult<VentureAppointment>> GetVentureAppointment(Guid key)
        {
            var ventureAppointment = await _dbContext.VentureAppointment.FindAsync(key);

            if (ventureAppointment == null)
            {
                return NotFound();
            }

            return ventureAppointment;
        }

        // PUT: api/VentureAppointments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutVentureAppointment(Guid key, VentureAppointment ventureAppointment)
        {
            if (key != ventureAppointment.VentureAppointmentKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(ventureAppointment).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureAppointmentExists(key))
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

        // POST: api/VentureAppointments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VentureAppointment>> PostVentureAppointment(VentureAppointment ventureAppointment)
        {
            _dbContext.VentureAppointment.Add(ventureAppointment);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetVentureAppointment", new { key = ventureAppointment.VentureAppointmentKey }, ventureAppointment);
        }

        // DELETE: api/VentureAppointments/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<VentureAppointment>> DeleteVentureAppointment(Guid key)
        {
            var ventureAppointment = await _dbContext.VentureAppointment.FindAsync(key);
            if (ventureAppointment == null)
            {
                return NotFound();
            }

            _dbContext.VentureAppointment.Remove(ventureAppointment);
            await _dbContext.SaveChangesAsync();

            return ventureAppointment;
        }

        private bool VentureAppointmentExists(Guid key)
        {
            return _dbContext.VentureAppointment.Any(e => e.VentureAppointmentKey == key);
        }
    }
}
