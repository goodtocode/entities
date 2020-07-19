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
    public class VentureAppointmentsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public VentureAppointmentsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/VentureAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentureAppointment>>> GetVentureAppointment()
        {
            return await _context.VentureAppointment.ToListAsync();
        }

        // GET: api/VentureAppointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentureAppointment>> GetVentureAppointment(int id)
        {
            var ventureAppointment = await _context.VentureAppointment.FindAsync(id);

            if (ventureAppointment == null)
            {
                return NotFound();
            }

            return ventureAppointment;
        }

        // PUT: api/VentureAppointments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentureAppointment(int id, VentureAppointment ventureAppointment)
        {
            if (id != ventureAppointment.VentureAppointmentId)
            {
                return BadRequest();
            }

            _context.Entry(ventureAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentureAppointmentExists(id))
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
            _context.VentureAppointment.Add(ventureAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentureAppointment", new { id = ventureAppointment.VentureAppointmentId }, ventureAppointment);
        }

        // DELETE: api/VentureAppointments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VentureAppointment>> DeleteVentureAppointment(int id)
        {
            var ventureAppointment = await _context.VentureAppointment.FindAsync(id);
            if (ventureAppointment == null)
            {
                return NotFound();
            }

            _context.VentureAppointment.Remove(ventureAppointment);
            await _context.SaveChangesAsync();

            return ventureAppointment;
        }

        private bool VentureAppointmentExists(int id)
        {
            return _context.VentureAppointment.Any(e => e.VentureAppointmentId == id);
        }
    }
}
