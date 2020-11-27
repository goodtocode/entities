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
//    public class LocationTypesController : ControllerBase
//    {
//        private readonly EntityDataContext _context;

//        public LocationTypesController(EntityDataContext context)
//        {
//            _context = context;
//        }

//        // GET: api/LocationTypes
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<LocationType>>> GetLocationType()
//        {
//            return await _context.LocationType.ToListAsync();
//        }

//        // GET: api/LocationTypes/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<LocationType>> GetLocationType(int id)
//        {
//            var locationType = await _context.LocationType.FindAsync(id);

//            if (locationType == null)
//            {
//                return NotFound();
//            }

//            return locationType;
//        }

//        // PUT: api/LocationTypes/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutLocationType(int id, LocationType locationType)
//        {
//            if (id != locationType.LocationTypeId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(locationType).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!LocationTypeExists(id))
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

//        // POST: api/LocationTypes
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<LocationType>> PostLocationType(LocationType locationType)
//        {
//            _context.LocationType.Add(locationType);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetLocationType", new { id = locationType.LocationTypeId }, locationType);
//        }

//        // DELETE: api/LocationTypes/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<LocationType>> DeleteLocationType(int id)
//        {
//            var locationType = await _context.LocationType.FindAsync(id);
//            if (locationType == null)
//            {
//                return NotFound();
//            }

//            _context.LocationType.Remove(locationType);
//            await _context.SaveChangesAsync();

//            return locationType;
//        }

//        private bool LocationTypeExists(int id)
//        {
//            return _context.LocationType.Any(e => e.LocationTypeId == id);
//        }
//    }
//}
