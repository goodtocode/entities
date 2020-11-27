//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GoodToCode.Shared.Domain;

//namespace GoodToCode.Occurrences.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EventSchedulesController : ControllerBase
//    {
//        private readonly OccurrencesDbContext _context;

//        public EventSchedulesController(OccurrencesDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/EventSchedules
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<EventSchedule>>> GetEventSchedule()
//        {
//            return await _context.EventSchedule.ToListAsync();
//        }

//        // GET: api/EventSchedules/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<EventSchedule>> GetEventSchedule(int id)
//        {
//            var eventSchedule = await _context.EventSchedule.FindAsync(id);

//            if (eventSchedule == null)
//            {
//                return NotFound();
//            }

//            return eventSchedule;
//        }

//        // PUT: api/EventSchedules/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutEventSchedule(int id, EventSchedule eventSchedule)
//        {
//            if (id != eventSchedule.EventScheduleId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(eventSchedule).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!EventScheduleExists(id))
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

//        // POST: api/EventSchedules
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<EventSchedule>> PostEventSchedule(EventSchedule eventSchedule)
//        {
//            _context.EventSchedule.Add(eventSchedule);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetEventSchedule", new { id = eventSchedule.EventScheduleId }, eventSchedule);
//        }

//        // DELETE: api/EventSchedules/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<EventSchedule>> DeleteEventSchedule(int id)
//        {
//            var eventSchedule = await _context.EventSchedule.FindAsync(id);
//            if (eventSchedule == null)
//            {
//                return NotFound();
//            }

//            _context.EventSchedule.Remove(eventSchedule);
//            await _context.SaveChangesAsync();

//            return eventSchedule;
//        }

//        private bool EventScheduleExists(int id)
//        {
//            return _context.EventSchedule.Any(e => e.EventScheduleId == id);
//        }
//    }
//}
