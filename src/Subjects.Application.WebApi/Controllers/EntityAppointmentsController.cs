using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Subjects.Application.Models;

namespace GoodToCode.Shared.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityAppointmentsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EntityAppointmentsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/EntityAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityAppointment>>> GetEntityAppointment()
        {
            return await _context.EntityAppointment.ToListAsync();
        }

        // GET: api/EntityAppointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityAppointment>> GetEntityAppointment(int id)
        {
            var entityAppointment = await _context.EntityAppointment.FindAsync(id);

            if (entityAppointment == null)
            {
                return NotFound();
            }

            return entityAppointment;
        }

        // PUT: api/EntityAppointments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityAppointment(int id, EntityAppointment entityAppointment)
        {
            if (id != entityAppointment.EntityAppointmentId)
            {
                return BadRequest();
            }

            _context.Entry(entityAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityAppointmentExists(id))
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

        // POST: api/EntityAppointments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EntityAppointment>> PostEntityAppointment(EntityAppointment entityAppointment)
        {
            _context.EntityAppointment.Add(entityAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityAppointment", new { id = entityAppointment.EntityAppointmentId }, entityAppointment);
        }

        // DELETE: api/EntityAppointments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EntityAppointment>> DeleteEntityAppointment(int id)
        {
            var entityAppointment = await _context.EntityAppointment.FindAsync(id);
            if (entityAppointment == null)
            {
                return NotFound();
            }

            _context.EntityAppointment.Remove(entityAppointment);
            await _context.SaveChangesAsync();

            return entityAppointment;
        }

        private bool EntityAppointmentExists(int id)
        {
            return _context.EntityAppointment.Any(e => e.EntityAppointmentId == id);
        }
    }
}
