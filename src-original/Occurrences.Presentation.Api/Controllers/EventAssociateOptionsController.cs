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
//    public class EventAssociateOptionsController : ControllerBase
//    {
//        private readonly OccurrencesDbContext _context;

//        public EventAssociateOptionsController(OccurrencesDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/EventAssociateOptions
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<EventAssociateOption>>> GetEventAssociateOption()
//        {
//            return await _context.EventAssociateOption.ToListAsync();
//        }

//        // GET: api/EventAssociateOptions/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<EventAssociateOption>> GetEventAssociateOption(int id)
//        {
//            var EventAssociateOption = await _context.EventAssociateOption.FindAsync(id);

//            if (EventAssociateOption == null)
//            {
//                return NotFound();
//            }

//            return EventAssociateOption;
//        }

//        // PUT: api/EventAssociateOptions/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutEventAssociateOption(int id, EventAssociateOption EventAssociateOption)
//        {
//            if (id != EventAssociateOption.EventAssociateOptionId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(EventAssociateOption).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!EventAssociateOptionExists(id))
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

//        // POST: api/EventAssociateOptions
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<EventAssociateOption>> PostEventAssociateOption(EventAssociateOption EventAssociateOption)
//        {
//            _context.EventAssociateOption.Add(EventAssociateOption);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetEventAssociateOption", new { id = EventAssociateOption.EventAssociateOptionId }, EventAssociateOption);
//        }

//        // DELETE: api/EventAssociateOptions/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<EventAssociateOption>> DeleteEventAssociateOption(int id)
//        {
//            var EventAssociateOption = await _context.EventAssociateOption.FindAsync(id);
//            if (EventAssociateOption == null)
//            {
//                return NotFound();
//            }

//            _context.EventAssociateOption.Remove(EventAssociateOption);
//            await _context.SaveChangesAsync();

//            return EventAssociateOption;
//        }

//        private bool EventAssociateOptionExists(int id)
//        {
//            return _context.EventAssociateOption.Any(e => e.EventAssociateOptionId == id);
//        }
//    }
//}
