//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GoodToCode.Shared.Domain;

//namespace GoodToCode.Locality.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LocationTimeRecurringsController : ControllerBase
//    {
//        private readonly EntityDataContext _context;

//        public LocationTimeRecurringsController(EntityDataContext context)
//        {
//            _context = context;
//        }

//        // GET: api/LocationTimeRecurrings
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<LocationTimeRecurring>>> GetLocationTimeRecurring()
//        {
//            return await _context.LocationTimeRecurring.ToListAsync();
//        }

//        // GET: api/LocationTimeRecurrings/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<LocationTimeRecurring>> GetLocationTimeRecurring(int id)
//        {
//            var locationTimeRecurring = await _context.LocationTimeRecurring.FindAsync(id);

//            if (locationTimeRecurring == null)
//            {
//                return NotFound();
//            }

//            return locationTimeRecurring;
//        }

//        // PUT: api/LocationTimeRecurrings/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutLocationTimeRecurring(int id, LocationTimeRecurring locationTimeRecurring)
//        {
//            if (id != locationTimeRecurring.LocationTimeRecurringId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(locationTimeRecurring).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!LocationTimeRecurringExists(id))
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

//        // POST: api/LocationTimeRecurrings
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<LocationTimeRecurring>> PostLocationTimeRecurring(LocationTimeRecurring locationTimeRecurring)
//        {
//            _context.LocationTimeRecurring.Add(locationTimeRecurring);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetLocationTimeRecurring", new { id = locationTimeRecurring.LocationTimeRecurringId }, locationTimeRecurring);
//        }

//        // DELETE: api/LocationTimeRecurrings/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<LocationTimeRecurring>> DeleteLocationTimeRecurring(int id)
//        {
//            var locationTimeRecurring = await _context.LocationTimeRecurring.FindAsync(id);
//            if (locationTimeRecurring == null)
//            {
//                return NotFound();
//            }

//            _context.LocationTimeRecurring.Remove(locationTimeRecurring);
//            await _context.SaveChangesAsync();

//            return locationTimeRecurring;
//        }

//        private bool LocationTimeRecurringExists(int id)
//        {
//            return _context.LocationTimeRecurring.Any(e => e.LocationTimeRecurringId == id);
//        }
//    }
//}
