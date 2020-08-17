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
    public class AppointmentVenturesController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public AppointmentVenturesController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/AppointmentVentures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentVenture>>> GetAppointmentVenture()
        {
            return await _dbContext.AppointmentVenture.ToListAsync();
        }

        // GET: api/AppointmentVentures/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AppointmentVenture>> GetAppointmentVenture(Guid key)
        {
            var AppointmentVenture = await _dbContext.AppointmentVenture.FindAsync(key);

            if (AppointmentVenture == null)
            {
                return NotFound();
            }

            return AppointmentVenture;
        }

        // PUT: api/AppointmentVentures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutAppointmentVenture(Guid key, AppointmentVenture AppointmentVenture)
        {
            if (key != AppointmentVenture.AppointmentVentureKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(AppointmentVenture).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentVentureExists(key))
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

        // POST: api/AppointmentVentures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AppointmentVenture>> PostAppointmentVenture(AppointmentVenture AppointmentVenture)
        {
            _dbContext.AppointmentVenture.Add(AppointmentVenture);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentVenture", new { key = AppointmentVenture.AppointmentVentureKey }, AppointmentVenture);
        }

        // DELETE: api/AppointmentVentures/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AppointmentVenture>> DeleteAppointmentVenture(Guid key)
        {
            var AppointmentVenture = await _dbContext.AppointmentVenture.FindAsync(key);
            if (AppointmentVenture == null)
            {
                return NotFound();
            }

            _dbContext.AppointmentVenture.Remove(AppointmentVenture);
            await _dbContext.SaveChangesAsync();

            return AppointmentVenture;
        }

        private bool AppointmentVentureExists(Guid key)
        {
            return _dbContext.AppointmentVenture.Any(e => e.AppointmentVentureKey == key);
        }
    }
}
