//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GoodToCode.Shared.Models;

//namespace GoodToCode.Occurrences.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EventEntityOptionsController : ControllerBase
//    {
//        private readonly OccurrencesDbContext _context;

//        public EventEntityOptionsController(OccurrencesDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/EventEntityOptions
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<EventEntityOption>>> GetEventEntityOption()
//        {
//            return await _context.EventEntityOption.ToListAsync();
//        }

//        // GET: api/EventEntityOptions/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<EventEntityOption>> GetEventEntityOption(int id)
//        {
//            var eventEntityOption = await _context.EventEntityOption.FindAsync(id);

//            if (eventEntityOption == null)
//            {
//                return NotFound();
//            }

//            return eventEntityOption;
//        }

//        // PUT: api/EventEntityOptions/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutEventEntityOption(int id, EventEntityOption eventEntityOption)
//        {
//            if (id != eventEntityOption.EventEntityOptionId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(eventEntityOption).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!EventEntityOptionExists(id))
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

//        // POST: api/EventEntityOptions
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<EventEntityOption>> PostEventEntityOption(EventEntityOption eventEntityOption)
//        {
//            _context.EventEntityOption.Add(eventEntityOption);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetEventEntityOption", new { id = eventEntityOption.EventEntityOptionId }, eventEntityOption);
//        }

//        // DELETE: api/EventEntityOptions/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<EventEntityOption>> DeleteEventEntityOption(int id)
//        {
//            var eventEntityOption = await _context.EventEntityOption.FindAsync(id);
//            if (eventEntityOption == null)
//            {
//                return NotFound();
//            }

//            _context.EventEntityOption.Remove(eventEntityOption);
//            await _context.SaveChangesAsync();

//            return eventEntityOption;
//        }

//        private bool EventEntityOptionExists(int id)
//        {
//            return _context.EventEntityOption.Any(e => e.EventEntityOptionId == id);
//        }
//    }
//}
