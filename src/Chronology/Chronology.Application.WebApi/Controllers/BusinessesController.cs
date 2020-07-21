using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public BusinessesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/Businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetBusiness()
        {
            return await _context.Business.ToListAsync();
        }

        // GET: api/Businesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetBusiness(int id)
        {
            var business = await _context.Business.FindAsync(id);

            if (business == null)
            {
                return NotFound();
            }

            return business;
        }

        // PUT: api/Businesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusiness(int id, Business business)
        {
            if (id != business.BusinessId)
            {
                return BadRequest();
            }

            _context.Entry(business).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        // POST: api/Businesses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Business>> PostBusiness(Business business)
        {
            _context.Business.Add(business);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusiness", new { id = business.BusinessId }, business);
        }

        // DELETE: api/Businesses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Business>> DeleteBusiness(int id)
        {
            var business = await _context.Business.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            _context.Business.Remove(business);
            await _context.SaveChangesAsync();

            return business;
        }

        private bool BusinessExists(int id)
        {
            return _context.Business.Any(e => e.BusinessId == id);
        }
    }
}
