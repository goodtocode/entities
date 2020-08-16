//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GoodToCode.Shared.Models;

//namespace GoodToCode.Chronology.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ScheduleSlotsController : ControllerBase
//    {
//        private readonly ChronologyDbContext _context;

//        public ScheduleSlotsController(ChronologyDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/ScheduleSlots
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ScheduleSlot>>> GetScheduleSlot()
//        {
//            return await _context.ScheduleSlot.ToListAsync();
//        }

//        // GET: api/ScheduleSlots/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ScheduleSlot>> GetScheduleSlot(int id)
//        {
//            var scheduleSlot = await _context.ScheduleSlot.FindAsync(id);

//            if (scheduleSlot == null)
//            {
//                return NotFound();
//            }

//            return scheduleSlot;
//        }

//        // PUT: api/ScheduleSlots/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutScheduleSlot(int id, ScheduleSlot scheduleSlot)
//        {
//            if (id != scheduleSlot.ScheduleSlotId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(scheduleSlot).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ScheduleSlotExists(id))
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

//        // POST: api/ScheduleSlots
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<ScheduleSlot>> PostScheduleSlot(ScheduleSlot scheduleSlot)
//        {
//            _context.ScheduleSlot.Add(scheduleSlot);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetScheduleSlot", new { id = scheduleSlot.ScheduleSlotId }, scheduleSlot);
//        }

//        // DELETE: api/ScheduleSlots/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<ScheduleSlot>> DeleteScheduleSlot(int id)
//        {
//            var scheduleSlot = await _context.ScheduleSlot.FindAsync(id);
//            if (scheduleSlot == null)
//            {
//                return NotFound();
//            }

//            _context.ScheduleSlot.Remove(scheduleSlot);
//            await _context.SaveChangesAsync();

//            return scheduleSlot;
//        }

//        private bool ScheduleSlotExists(int id)
//        {
//            return _context.ScheduleSlot.Any(e => e.ScheduleSlotId == id);
//        }
//    }
//}
