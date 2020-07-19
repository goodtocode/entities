using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Entities.WebApi1.Models;

namespace GoodToCode.Entities.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordStatesController : ControllerBase
    {
        private readonly EntityDataContext _context;

        public RecordStatesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: api/RecordStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordState>>> GetRecordState()
        {
            return await _context.RecordState.ToListAsync();
        }

        // GET: api/RecordStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecordState>> GetRecordState(int id)
        {
            var recordState = await _context.RecordState.FindAsync(id);

            if (recordState == null)
            {
                return NotFound();
            }

            return recordState;
        }

        // PUT: api/RecordStates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordState(int id, RecordState recordState)
        {
            if (id != recordState.RecordStateId)
            {
                return BadRequest();
            }

            _context.Entry(recordState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordStateExists(id))
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

        // POST: api/RecordStates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RecordState>> PostRecordState(RecordState recordState)
        {
            _context.RecordState.Add(recordState);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecordStateExists(recordState.RecordStateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecordState", new { id = recordState.RecordStateId }, recordState);
        }

        // DELETE: api/RecordStates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecordState>> DeleteRecordState(int id)
        {
            var recordState = await _context.RecordState.FindAsync(id);
            if (recordState == null)
            {
                return NotFound();
            }

            _context.RecordState.Remove(recordState);
            await _context.SaveChangesAsync();

            return recordState;
        }

        private bool RecordStateExists(int id)
        {
            return _context.RecordState.Any(e => e.RecordStateId == id);
        }
    }
}
