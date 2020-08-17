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
    public class AppointmentAssociatesController : ControllerBase
    {
        private readonly SubjectsDbContext _dbContext;

        public AppointmentAssociatesController(SubjectsDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/AppointmentAssociates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentAssociate>>> GetAppointmentAssociate()
        {
            return await _dbContext.AppointmentAssociate.ToListAsync();
        }

        // GET: api/AppointmentAssociates/5
        [HttpGet("{key}")]
        public async Task<ActionResult<AppointmentAssociate>> GetAppointmentAssociate(Guid key)
        {
            var AppointmentAssociate = await _dbContext.AppointmentAssociate.FindAsync(key);

            if (AppointmentAssociate == null)
            {
                return NotFound();
            }

            return AppointmentAssociate;
        }

        // PUT: api/AppointmentAssociates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{key}")]
        public async Task<IActionResult> PutAppointmentAssociate(Guid key, AppointmentAssociate AppointmentAssociate)
        {
            if (key != AppointmentAssociate.AppointmentAssociateKey)
            {
                return BadRequest();
            }

            _dbContext.Entry(AppointmentAssociate).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentAssociateExists(key))
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

        // POST: api/AppointmentAssociates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AppointmentAssociate>> PostAppointmentAssociate(AppointmentAssociate AppointmentAssociate)
        {
            _dbContext.AppointmentAssociate.Add(AppointmentAssociate);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentAssociate", new { key = AppointmentAssociate.AppointmentAssociateKey }, AppointmentAssociate);
        }

        // DELETE: api/AppointmentAssociates/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<AppointmentAssociate>> DeleteAppointmentAssociate(Guid key)
        {
            var AppointmentAssociate = await _dbContext.AppointmentAssociate.FindAsync(key);
            if (AppointmentAssociate == null)
            {
                return NotFound();
            }

            _dbContext.AppointmentAssociate.Remove(AppointmentAssociate);
            await _dbContext.SaveChangesAsync();

            return AppointmentAssociate;
        }

        private bool AppointmentAssociateExists(Guid key)
        {
            return _dbContext.AppointmentAssociate.Any(e => e.AppointmentAssociateKey == key);
        }
    }
}
