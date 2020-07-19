using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Entities.WebApi1.Models;

namespace GoodToCode.Entities.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventOptionsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EventOptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/EventOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventOption>>> GetEventOption()
        {
            return await _context.EventOption.ToListAsync();
        }

        // GET: api/EventOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventOption>> GetEventOption(int id)
        {
            var eventOption = await _context.EventOption.FindAsync(id);

            if (eventOption == null)
            {
                return NotFound();
            }

            return eventOption;
        }

        // PUT: api/EventOptions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventOption(int id, EventOption eventOption)
        {
            if (id != eventOption.EventOptionId)
            {
                return BadRequest();
            }

            _context.Entry(eventOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventOptionExists(id))
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

        // POST: api/EventOptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventOption>> PostEventOption(EventOption eventOption)
        {
            _context.EventOption.Add(eventOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventOption", new { id = eventOption.EventOptionId }, eventOption);
        }

        // DELETE: api/EventOptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventOption>> DeleteEventOption(int id)
        {
            var eventOption = await _context.EventOption.FindAsync(id);
            if (eventOption == null)
            {
                return NotFound();
            }

            _context.EventOption.Remove(eventOption);
            await _context.SaveChangesAsync();

            return eventOption;
        }

        private bool EventOptionExists(int id)
        {
            return _context.EventOption.Any(e => e.EventOptionId == id);
        }
    }
}
