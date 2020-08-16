//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GoodToCode.Shared.Models;

//namespace GoodToCode.Chronology.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SlotResourcesController : ControllerBase
//    {
//        private readonly ChronoloyDbContext _context;

//        public SlotResourcesController(ChronoloyDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/SlotResources
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<SlotResource>>> GetSlotResource()
//        {
//            return await _context.SlotResource.ToListAsync();
//        }

//        // GET: api/SlotResources/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<SlotResource>> GetSlotResource(int id)
//        {
//            var slotResource = await _context.SlotResource.FindAsync(id);

//            if (slotResource == null)
//            {
//                return NotFound();
//            }

//            return slotResource;
//        }

//        // PUT: api/SlotResources/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutSlotResource(int id, SlotResource slotResource)
//        {
//            if (id != slotResource.SlotResourceId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(slotResource).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SlotResourceExists(id))
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

//        // POST: api/SlotResources
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<SlotResource>> PostSlotResource(SlotResource slotResource)
//        {
//            _context.SlotResource.Add(slotResource);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetSlotResource", new { id = slotResource.SlotResourceId }, slotResource);
//        }

//        // DELETE: api/SlotResources/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<SlotResource>> DeleteSlotResource(int id)
//        {
//            var slotResource = await _context.SlotResource.FindAsync(id);
//            if (slotResource == null)
//            {
//                return NotFound();
//            }

//            _context.SlotResource.Remove(slotResource);
//            await _context.SaveChangesAsync();

//            return slotResource;
//        }

//        private bool SlotResourceExists(int id)
//        {
//            return _context.SlotResource.Any(e => e.SlotResourceId == id);
//        }
//    }
//}
