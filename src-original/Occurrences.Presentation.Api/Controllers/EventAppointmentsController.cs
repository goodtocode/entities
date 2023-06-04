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
//    public class AppointmentEventsController : ControllerBase
//    {
//        private readonly OccurrencesDbContext _context;

//        public AppointmentEventsController(OccurrencesDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/AppointmentEvents
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<AppointmentEvent>>> GetAppointmentEvent()
//        {
//            return await _context.AppointmentEvent.ToListAsync();
//        }

//        // GET: api/AppointmentEvents/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<AppointmentEvent>> GetAppointmentEvent(int id)
//        {
//            var AppointmentEvent = await _context.AppointmentEvent.FindAsync(id);

//            if (AppointmentEvent == null)
//            {
//                return NotFound();
//            }

//            return AppointmentEvent;
//        }

//        // PUT: api/AppointmentEvents/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAppointmentEvent(int id, AppointmentEvent AppointmentEvent)
//        {
//            if (id != AppointmentEvent.AppointmentEventId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(AppointmentEvent).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!AppointmentEventExists(id))
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

//        // POST: api/AppointmentEvents
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<AppointmentEvent>> PostAppointmentEvent(AppointmentEvent AppointmentEvent)
//        {
//            _context.AppointmentEvent.Add(AppointmentEvent);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetAppointmentEvent", new { id = AppointmentEvent.AppointmentEventId }, AppointmentEvent);
//        }

//        // DELETE: api/AppointmentEvents/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<AppointmentEvent>> DeleteAppointmentEvent(int id)
//        {
//            var AppointmentEvent = await _context.AppointmentEvent.FindAsync(id);
//            if (AppointmentEvent == null)
//            {
//                return NotFound();
//            }

//            _context.AppointmentEvent.Remove(AppointmentEvent);
//            await _context.SaveChangesAsync();

//            return AppointmentEvent;
//        }

//        private bool AppointmentEventExists(int id)
//        {
//            return _context.AppointmentEvent.Any(e => e.AppointmentEventId == id);
//        }
//    }
//}
