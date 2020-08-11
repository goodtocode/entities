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
    public class AssociateAppointmentsController : ControllerBase
    {
        private readonly SubjectsDbContext _context;

        public AssociateAppointmentsController(SubjectsDbContext context)
        {
            _context = context;
        }

        // GET: api/AssociateAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateAppointment>>> GetAssociateAppointment()
        {
            return await _context.AssociateAppointment.ToListAsync();
        }

        // GET: api/AssociateAppointments/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateAppointment>> GetAssociateAppointment(Guid key)
        {
            var AssociateAppointment = await _context.AssociateAppointment.FindAsync(key);

            if (AssociateAppointment == null)
            {
                return NotFound();
            }

            return AssociateAppointment;
        }

        // PUT: api/AssociateAppointments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutAssociateAppointment(Guid key, AssociateAppointment AssociateAppointment)
        {
            if (key != AssociateAppointment.AssociateAppointmentKey)
            {
                return BadRequest();
            }

            _context.Entry(AssociateAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociateAppointmentExists(key))
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

        // POST: api/AssociateAppointments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssociateAppointment>> PostAssociateAppointment(AssociateAppointment AssociateAppointment)
        {
            _context.AssociateAppointment.Add(AssociateAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssociateAppointment", new { key = AssociateAppointment.AssociateAppointmentKey }, AssociateAppointment);
        }

        // DELETE: api/AssociateAppointments/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateAppointment>> DeleteAssociateAppointment(Guid key)
        {
            var AssociateAppointment = await _context.AssociateAppointment.FindAsync(key);
            if (AssociateAppointment == null)
            {
                return NotFound();
            }

            _context.AssociateAppointment.Remove(AssociateAppointment);
            await _context.SaveChangesAsync();

            return AssociateAppointment;
        }

        private bool AssociateAppointmentExists(Guid key)
        {
            return _context.AssociateAppointment.Any(e => e.AssociateAppointmentKey == key);
        }
    }
}
