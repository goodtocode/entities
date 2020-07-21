using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Subjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventDetailsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EventDetailsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/EventDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDetail>>> GetEventDetail()
        {
            return await _context.EventDetail.ToListAsync();
        }

        // GET: api/EventDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetail>> GetEventDetail(int id)
        {
            var eventDetail = await _context.EventDetail.FindAsync(id);

            if (eventDetail == null)
            {
                return NotFound();
            }

            return eventDetail;
        }

        // PUT: api/EventDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventDetail(int id, EventDetail eventDetail)
        {
            if (id != eventDetail.EventDetailId)
            {
                return BadRequest();
            }

            _context.Entry(eventDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventDetailExists(id))
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

        // POST: api/EventDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventDetail>> PostEventDetail(EventDetail eventDetail)
        {
            _context.EventDetail.Add(eventDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventDetail", new { id = eventDetail.EventDetailId }, eventDetail);
        }

        // DELETE: api/EventDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventDetail>> DeleteEventDetail(int id)
        {
            var eventDetail = await _context.EventDetail.FindAsync(id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            _context.EventDetail.Remove(eventDetail);
            await _context.SaveChangesAsync();

            return eventDetail;
        }

        private bool EventDetailExists(int id)
        {
            return _context.EventDetail.Any(e => e.EventDetailId == id);
        }
    }
}
