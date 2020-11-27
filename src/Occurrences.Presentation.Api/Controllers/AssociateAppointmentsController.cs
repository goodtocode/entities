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
    public class AssociateAppointmentsController : ControllerBase
    {
        private readonly OccurrencesDbContext _dbContext;

        public AssociateAppointmentsController(OccurrencesDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/AssociateAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociateAppointment>>> GetAssociateAppointment()
        {
            return await _dbContext.AssociateAppointment.ToListAsync();
        }

        // GET: api/AssociateAppointments/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AssociateAppointment>> GetAssociateAppointment(Guid key)
        {
            var AssociateAppointment = await _dbContext.AssociateAppointment.FindAsync(key);

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

            _dbContext.Entry(AssociateAppointment).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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
            _dbContext.AssociateAppointment.Add(AssociateAppointment);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetAssociateAppointment", new { key = AssociateAppointment.AssociateAppointmentKey }, AssociateAppointment);
        }

        // DELETE: api/AssociateAppointments/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AssociateAppointment>> DeleteAssociateAppointment(Guid key)
        {
            var AssociateAppointment = await _dbContext.AssociateAppointment.FindAsync(key);
            if (AssociateAppointment == null)
            {
                return NotFound();
            }

            _dbContext.AssociateAppointment.Remove(AssociateAppointment);
            await _dbContext.SaveChangesAsync();

            return AssociateAppointment;
        }

        private bool AssociateAppointmentExists(Guid key)
        {
            return _dbContext.AssociateAppointment.Any(e => e.AssociateAppointmentKey == key);
        }
    }
}
