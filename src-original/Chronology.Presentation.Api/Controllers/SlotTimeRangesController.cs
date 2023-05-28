//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GoodToCode.Shared.Domain;

//namespace GoodToCode.Chronology.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SlotTimeRangesController : ControllerBase
//    {
//        private readonly ChronologyDbContext _context;

//        public SlotTimeRangesController(ChronologyDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/SlotTimeRanges
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<SlotTimeRange>>> GetSlotTimeRange()
//        {
//            return await _context.SlotTimeRange.ToListAsync();
//        }

//        // GET: api/SlotTimeRanges/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<SlotTimeRange>> GetSlotTimeRange(int id)
//        {
//            var slotTimeRange = await _context.SlotTimeRange.FindAsync(id);

//            if (slotTimeRange == null)
//            {
//                return NotFound();
//            }

//            return slotTimeRange;
//        }

//        // PUT: api/SlotTimeRanges/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutSlotTimeRange(int id, SlotTimeRange slotTimeRange)
//        {
//            if (id != slotTimeRange.SlotTimeRangeId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(slotTimeRange).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SlotTimeRangeExists(id))
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

//        // POST: api/SlotTimeRanges
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<SlotTimeRange>> PostSlotTimeRange(SlotTimeRange slotTimeRange)
//        {
//            _context.SlotTimeRange.Add(slotTimeRange);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetSlotTimeRange", new { id = slotTimeRange.SlotTimeRangeId }, slotTimeRange);
//        }

//        // DELETE: api/SlotTimeRanges/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<SlotTimeRange>> DeleteSlotTimeRange(int id)
//        {
//            var slotTimeRange = await _context.SlotTimeRange.FindAsync(id);
//            if (slotTimeRange == null)
//            {
//                return NotFound();
//            }

//            _context.SlotTimeRange.Remove(slotTimeRange);
//            await _context.SaveChangesAsync();

//            return slotTimeRange;
//        }

//        private bool SlotTimeRangeExists(int id)
//        {
//            return _context.SlotTimeRange.Any(e => e.SlotTimeRangeId == id);
//        }
//    }
//}
