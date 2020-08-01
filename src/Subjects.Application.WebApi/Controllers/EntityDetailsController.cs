using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Subjects.Application.Models;

namespace GoodToCode.Shared.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityDetailsController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public EntityDetailsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/EntityDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityDetail>>> GetEntityDetail()
        {
            return await _context.EntityDetail.ToListAsync();
        }

        // GET: api/EntityDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityDetail>> GetEntityDetail(int id)
        {
            var entityDetail = await _context.EntityDetail.FindAsync(id);

            if (entityDetail == null)
            {
                return NotFound();
            }

            return entityDetail;
        }

        // PUT: api/EntityDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityDetail(int id, EntityDetail entityDetail)
        {
            if (id != entityDetail.EntityDetailId)
            {
                return BadRequest();
            }

            _context.Entry(entityDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityDetailExists(id))
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

        // POST: api/EntityDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EntityDetail>> PostEntityDetail(EntityDetail entityDetail)
        {
            _context.EntityDetail.Add(entityDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityDetail", new { id = entityDetail.EntityDetailId }, entityDetail);
        }

        // DELETE: api/EntityDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EntityDetail>> DeleteEntityDetail(int id)
        {
            var entityDetail = await _context.EntityDetail.FindAsync(id);
            if (entityDetail == null)
            {
                return NotFound();
            }

            _context.EntityDetail.Remove(entityDetail);
            await _context.SaveChangesAsync();

            return entityDetail;
        }

        private bool EntityDetailExists(int id)
        {
            return _context.EntityDetail.Any(e => e.EntityDetailId == id);
        }
    }
}
