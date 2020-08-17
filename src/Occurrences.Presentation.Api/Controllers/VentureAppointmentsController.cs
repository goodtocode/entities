using GoodToCode.Occurrences.Infrastructure;
using GoodToCode.Occurrences.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Occurrences.Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentureAppointmentsController : ControllerBase
    {
        private readonly OccurrencesDbContext _dbContext;

        public VentureAppointmentsController(OccurrencesDbContext context)
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
            var VentureAppointment = await _dbContext.VentureAppointment.FindAsync(key);

            if (VentureAppointment == null)
            {
                return NotFound();
            }

            return VentureAppointment;
        }

        // PUT: api/VentureAppointments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutVentureAppointment(Guid key, VentureAppointment VentureAppointment)
        {
            if (key != VentureAppointment.VentureAppointmentKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(VentureAppointment).State = EntityState.Modified;

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
        public async Task<ActionResult<VentureAppointment>> PostVentureAppointment(VentureAppointment VentureAppointment)
        {
            _dbContext.VentureAppointment.Add(VentureAppointment);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetVentureAppointment", new { key = VentureAppointment.VentureAppointmentKey }, VentureAppointment);
        }

        // DELETE: api/VentureAppointments/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<VentureAppointment>> DeleteVentureAppointment(Guid key)
        {
            var VentureAppointment = await _dbContext.VentureAppointment.FindAsync(key);
            if (VentureAppointment == null)
            {
                return NotFound();
            }

            _dbContext.VentureAppointment.Remove(VentureAppointment);
            await _dbContext.SaveChangesAsync();

            return VentureAppointment;
        }

        private bool VentureAppointmentExists(Guid key)
        {
            return _dbContext.VentureAppointment.Any(e => e.VentureAppointmentKey == key);
        }
    }
}
