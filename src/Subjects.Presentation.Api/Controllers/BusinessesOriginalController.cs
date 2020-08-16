using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesOriginalController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public BusinessesOriginalController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/Businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetBusiness()
        {
            return await _dbContext.Business.ToListAsync();
        }

        // GET: api/Businesses/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Business>> GetBusiness(Guid key)
        {
            var business = await _dbContext.Business.FindAsync(key);

            if (business == null)
            {
                return NotFound();
            }

            return business;
        }

        // PUT: api/Businesses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutBusiness(Guid key, Business business)
        {
            if (key != business.BusinessKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(business).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(key))
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
            _dbContext.Business.Add(business);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetBusiness", new { key = business.BusinessKey }, business);
        }

        // DELETE: api/Businesses/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Business>> DeleteBusiness(Guid key)
        {
            var business = await _dbContext.Business.FindAsync(key);
            if (business == null)
            {
                return NotFound();
            }

            _dbContext.Business.Remove(business);
            await _dbContext.SaveChangesAsync();

            return business;
        }

        private bool BusinessExists(Guid key)
        {
            return _dbContext.Business.Any(e => e.BusinessKey == key);
        }
    }
}
