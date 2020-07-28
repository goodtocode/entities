using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Shared.Models;

namespace GoodToCode.Occurrences.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventAppointmentsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EventAppointmentsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/EventAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventAppointment>>> GetEventAppointment()
        {
            return await _context.EventAppointment.ToListAsync();
        }

        // GET: api/EventAppointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventAppointment>> GetEventAppointment(int id)
        {
            var eventAppointment = await _context.EventAppointment.FindAsync(id);

            if (eventAppointment == null)
            {
                return NotFound();
            }

            return eventAppointment;
        }

        // PUT: api/EventAppointments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventAppointment(int id, EventAppointment eventAppointment)
        {
            if (id != eventAppointment.EventAppointmentId)
            {
                return BadRequest();
            }

            _context.Entry(eventAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventAppointmentExists(id))
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

        // POST: api/EventAppointments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventAppointment>> PostEventAppointment(EventAppointment eventAppointment)
        {
            _context.EventAppointment.Add(eventAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventAppointment", new { id = eventAppointment.EventAppointmentId }, eventAppointment);
        }

        // DELETE: api/EventAppointments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventAppointment>> DeleteEventAppointment(int id)
        {
            var eventAppointment = await _context.EventAppointment.FindAsync(id);
            if (eventAppointment == null)
            {
                return NotFound();
            }

            _context.EventAppointment.Remove(eventAppointment);
            await _context.SaveChangesAsync();

            return eventAppointment;
        }

        private bool EventAppointmentExists(int id)
        {
            return _context.EventAppointment.Any(e => e.EventAppointmentId == id);
        }
    }
}
