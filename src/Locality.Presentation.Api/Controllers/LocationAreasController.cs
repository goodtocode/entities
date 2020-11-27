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
//    public class LocationAreasController : ControllerBase
//    {
//        private readonly EntityDataContext _context;

//        public LocationAreasController(EntityDataContext context)
//        {
//            _context = context;
//        }

//        // GET: api/LocationAreas
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<LocationArea>>> GetLocationArea()
//        {
//            return await _context.LocationArea.ToListAsync();
//        }

//        // GET: api/LocationAreas/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<LocationArea>> GetLocationArea(int id)
//        {
//            var locationArea = await _context.LocationArea.FindAsync(id);

//            if (locationArea == null)
//            {
//                return NotFound();
//            }

//            return locationArea;
//        }

//        // PUT: api/LocationAreas/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutLocationArea(int id, LocationArea locationArea)
//        {
//            if (id != locationArea.LocationAreaId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(locationArea).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!LocationAreaExists(id))
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

//        // POST: api/LocationAreas
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<LocationArea>> PostLocationArea(LocationArea locationArea)
//        {
//            _context.LocationArea.Add(locationArea);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetLocationArea", new { id = locationArea.LocationAreaId }, locationArea);
//        }

//        // DELETE: api/LocationAreas/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<LocationArea>> DeleteLocationArea(int id)
//        {
//            var locationArea = await _context.LocationArea.FindAsync(id);
//            if (locationArea == null)
//            {
//                return NotFound();
//            }

//            _context.LocationArea.Remove(locationArea);
//            await _context.SaveChangesAsync();

//            return locationArea;
//        }

//        private bool LocationAreaExists(int id)
//        {
//            return _context.LocationArea.Any(e => e.LocationAreaId == id);
//        }
//    }
//}
