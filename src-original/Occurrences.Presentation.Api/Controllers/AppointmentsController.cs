﻿//using GoodToCode.Occurrences.Models;
//using GoodToCode.Occurrences.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GoodToCode.Occurrences.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AppointmentsController : ControllerBase
//    {
//        private readonly OccurrencesDbContext _context;

//        public AppointmentsController(OccurrencesDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Appointments
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
//        {
//            return await _context.Appointment.ToListAsync();
//        }

//        // GET: api/Appointments/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Appointment>> GetAppointment(int id)
//        {
//            var appointment = await _context.Appointment.FindAsync(id);

//            if (appointment == null)
//            {
//                return NotFound();
//            }

//            return appointment;
//        }

//        // PUT: api/Appointments/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
//        {
//            if (id != appointment.AppointmentId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(appointment).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!AppointmentExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Appointments
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
//        {
//            _context.Appointment.Add(appointment);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetAppointment", new { id = appointment.AppointmentId }, appointment);
//        }

//        // DELETE: api/Appointments/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
//        {
//            var appointment = await _context.Appointment.FindAsync(id);
//            if (appointment == null)
//            {
//                return NotFound();
//            }

//            _context.Appointment.Remove(appointment);
//            await _context.SaveChangesAsync();

//            return appointment;
//        }

//        private bool AppointmentExists(int id)
//        {
//            return _context.Appointment.Any(e => e.AppointmentId == id);
//        }
//    }
//}
