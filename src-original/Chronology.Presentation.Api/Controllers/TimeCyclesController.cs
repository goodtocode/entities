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
//    public class TimeCyclesController : ControllerBase
//    {
//        private readonly ChronologyDbContext _context;

//        public TimeCyclesController(ChronologyDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/TimeCycles
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<TimeCycle>>> GetTimeCycle()
//        {
//            return await _context.TimeCycle.ToListAsync();
//        }

//        // GET: api/TimeCycles/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<TimeCycle>> GetTimeCycle(int id)
//        {
//            var timeCycle = await _context.TimeCycle.FindAsync(id);

//            if (timeCycle == null)
//            {
//                return NotFound();
//            }

//            return timeCycle;
//        }

//        // PUT: api/TimeCycles/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutTimeCycle(int id, TimeCycle timeCycle)
//        {
//            if (id != timeCycle.TimeCycleId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(timeCycle).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!TimeCycleExists(id))
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

//        // POST: api/TimeCycles
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<TimeCycle>> PostTimeCycle(TimeCycle timeCycle)
//        {
//            _context.TimeCycle.Add(timeCycle);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetTimeCycle", new { id = timeCycle.TimeCycleId }, timeCycle);
//        }

//        // DELETE: api/TimeCycles/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<TimeCycle>> DeleteTimeCycle(int id)
//        {
//            var timeCycle = await _context.TimeCycle.FindAsync(id);
//            if (timeCycle == null)
//            {
//                return NotFound();
//            }

//            _context.TimeCycle.Remove(timeCycle);
//            await _context.SaveChangesAsync();

//            return timeCycle;
//        }

//        private bool TimeCycleExists(int id)
//        {
//            return _context.TimeCycle.Any(e => e.TimeCycleId == id);
//        }
//    }
//}
