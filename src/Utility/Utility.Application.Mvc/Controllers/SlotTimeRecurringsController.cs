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
    public class SlotTimeRecurringsController : Controller
    {
        private readonly EntityDataContext _context;

        public SlotTimeRecurringsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: SlotTimeRecurrings
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.SlotTimeRecurring.Include(s => s.RecordStateKeyNavigation).Include(s => s.SlotKeyNavigation).Include(s => s.TimeRecurringKeyNavigation).Include(s => s.TimeTypeKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: SlotTimeRecurrings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotTimeRecurring = await _context.SlotTimeRecurring
                .Include(s => s.RecordStateKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .Include(s => s.TimeRecurringKeyNavigation)
                .Include(s => s.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotTimeRecurringId == id);
            if (slotTimeRecurring == null)
            {
                return NotFound();
            }

            return View(slotTimeRecurring);
        }

        // GET: SlotTimeRecurrings/Create
        public IActionResult Create()
        {
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription");
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey");
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription");
            return View();
        }

        // POST: SlotTimeRecurrings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlotTimeRecurringId,SlotTimeRecurringKey,SlotKey,TimeRecurringKey,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] SlotTimeRecurring slotTimeRecurring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slotTimeRecurring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotTimeRecurring.RecordStateKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotTimeRecurring.SlotKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", slotTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", slotTimeRecurring.TimeTypeKey);
            return View(slotTimeRecurring);
        }

        // GET: SlotTimeRecurrings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotTimeRecurring = await _context.SlotTimeRecurring.FindAsync(id);
            if (slotTimeRecurring == null)
            {
                return NotFound();
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotTimeRecurring.RecordStateKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotTimeRecurring.SlotKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", slotTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", slotTimeRecurring.TimeTypeKey);
            return View(slotTimeRecurring);
        }

        // POST: SlotTimeRecurrings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlotTimeRecurringId,SlotTimeRecurringKey,SlotKey,TimeRecurringKey,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] SlotTimeRecurring slotTimeRecurring)
        {
            if (id != slotTimeRecurring.SlotTimeRecurringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slotTimeRecurring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotTimeRecurringExists(slotTimeRecurring.SlotTimeRecurringId))
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
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotTimeRecurring.RecordStateKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotTimeRecurring.SlotKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", slotTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", slotTimeRecurring.TimeTypeKey);
            return View(slotTimeRecurring);
        }

        // GET: SlotTimeRecurrings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotTimeRecurring = await _context.SlotTimeRecurring
                .Include(s => s.RecordStateKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .Include(s => s.TimeRecurringKeyNavigation)
                .Include(s => s.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotTimeRecurringId == id);
            if (slotTimeRecurring == null)
            {
                return NotFound();
            }

            return View(slotTimeRecurring);
        }

        // POST: SlotTimeRecurrings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slotTimeRecurring = await _context.SlotTimeRecurring.FindAsync(id);
            _context.SlotTimeRecurring.Remove(slotTimeRecurring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotTimeRecurringExists(int id)
        {
            return _context.SlotTimeRecurring.Any(e => e.SlotTimeRecurringId == id);
        }
    }
}
