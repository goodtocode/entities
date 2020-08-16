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
//    public class TimeTypesController : ControllerBase
//    {
//        private readonly ChronologyDbContext _context;

//        public TimeTypesController(ChronologyDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/TimeTypes
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<TimeType>>> GetTimeType()
//        {
//            return await _context.TimeType.ToListAsync();
//        }

//        // GET: api/TimeTypes/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<TimeType>> GetTimeType(int id)
//        {
//            var timeType = await _context.TimeType.FindAsync(id);

//            if (timeType == null)
//            {
//                return NotFound();
//            }

//            return timeType;
//        }

//        // PUT: api/TimeTypes/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutTimeType(int id, TimeType timeType)
//        {
//            if (id != timeType.TimeTypeId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(timeType).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!TimeTypeExists(id))
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

//        // POST: api/TimeTypes
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<TimeType>> PostTimeType(TimeType timeType)
//        {
//            _context.TimeType.Add(timeType);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetTimeType", new { id = timeType.TimeTypeId }, timeType);
//        }

//        // DELETE: api/TimeTypes/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<TimeType>> DeleteTimeType(int id)
//        {
//            var timeType = await _context.TimeType.FindAsync(id);
//            if (timeType == null)
//            {
//                return NotFound();
//            }

//            _context.TimeType.Remove(timeType);
//            await _context.SaveChangesAsync();

//            return timeType;
//        }

//        private bool TimeTypeExists(int id)
//        {
//            return _context.TimeType.Any(e => e.TimeTypeId == id);
//        }
//    }
//}
