using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Subjects.Controllers
{
    public class SlotsController : Controller
    {
        private readonly EntityDataContext _context;

        public SlotsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: Slots
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.Slot.Include(s => s.RecordStateKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: Slots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .Include(s => s.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotId == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // GET: Slots/Create
        public IActionResult Create()
        {
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            return View();
        }

        // POST: Slots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlotId,SlotKey,SlotName,SlotDescription,RecordStateKey,CreatedDate,ModifiedDate")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slot.RecordStateKey);
            return View(slot);
        }

        // GET: Slots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot.FindAsync(id);
            if (slot == null)
            {
                return NotFound();
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slot.RecordStateKey);
            return View(slot);
        }

        // POST: Slots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlotId,SlotKey,SlotName,SlotDescription,RecordStateKey,CreatedDate,ModifiedDate")] Slot slot)
        {
            if (id != slot.SlotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotExists(slot.SlotId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slot.RecordStateKey);
            return View(slot);
        }

        // GET: Slots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.Slot
                .Include(s => s.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotId == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // POST: Slots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slot = await _context.Slot.FindAsync(id);
            _context.Slot.Remove(slot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotExists(int id)
        {
            return _context.Slot.Any(e => e.SlotId == id);
        }
    }
}
