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
//    public class SlotTimeRecurringsController : ControllerBase
//    {
//        private readonly ChronologyDbContext _context;

//        public SlotTimeRecurringsController(ChronologyDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/SlotTimeRecurrings
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<SlotTimeRecurring>>> GetSlotTimeRecurring()
//        {
//            return await _context.SlotTimeRecurring.ToListAsync();
//        }

//        // GET: api/SlotTimeRecurrings/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<SlotTimeRecurring>> GetSlotTimeRecurring(int id)
//        {
//            var slotTimeRecurring = await _context.SlotTimeRecurring.FindAsync(id);

//            if (slotTimeRecurring == null)
//            {
//                return NotFound();
//            }

//            return slotTimeRecurring;
//        }

//        // PUT: api/SlotTimeRecurrings/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutSlotTimeRecurring(int id, SlotTimeRecurring slotTimeRecurring)
//        {
//            if (id != slotTimeRecurring.SlotTimeRecurringId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(slotTimeRecurring).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SlotTimeRecurringExists(id))
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

//        // POST: api/SlotTimeRecurrings
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<SlotTimeRecurring>> PostSlotTimeRecurring(SlotTimeRecurring slotTimeRecurring)
//        {
//            _context.SlotTimeRecurring.Add(slotTimeRecurring);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetSlotTimeRecurring", new { id = slotTimeRecurring.SlotTimeRecurringId }, slotTimeRecurring);
//        }

//        // DELETE: api/SlotTimeRecurrings/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<SlotTimeRecurring>> DeleteSlotTimeRecurring(int id)
//        {
//            var slotTimeRecurring = await _context.SlotTimeRecurring.FindAsync(id);
//            if (slotTimeRecurring == null)
//            {
//                return NotFound();
//            }

//            _context.SlotTimeRecurring.Remove(slotTimeRecurring);
//            await _context.SaveChangesAsync();

//            return slotTimeRecurring;
//        }

//        private bool SlotTimeRecurringExists(int id)
//        {
//            return _context.SlotTimeRecurring.Any(e => e.SlotTimeRecurringId == id);
//        }
//    }
//}
