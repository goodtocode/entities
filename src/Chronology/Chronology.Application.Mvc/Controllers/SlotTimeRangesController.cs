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
    public class SlotTimeRangesController : Controller
    {
        private readonly EntityDataContext _context;

        public SlotTimeRangesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: SlotTimeRanges
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.SlotTimeRange.Include(s => s.RecordStateKeyNavigation).Include(s => s.SlotKeyNavigation).Include(s => s.TimeRangeKeyNavigation).Include(s => s.TimeTypeKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: SlotTimeRanges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotTimeRange = await _context.SlotTimeRange
                .Include(s => s.RecordStateKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .Include(s => s.TimeRangeKeyNavigation)
                .Include(s => s.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotTimeRangeId == id);
            if (slotTimeRange == null)
            {
                return NotFound();
            }

            return View(slotTimeRange);
        }

        // GET: SlotTimeRanges/Create
        public IActionResult Create()
        {
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription");
            ViewData["TimeRangeKey"] = new SelectList(_context.TimeRange, "TimeRangeKey", "TimeRangeKey");
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription");
            return View();
        }

        // POST: SlotTimeRanges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlotTimeRangeId,SlotTimeRangeKey,SlotKey,TimeRangeKey,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] SlotTimeRange slotTimeRange)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slotTimeRange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotTimeRange.RecordStateKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotTimeRange.SlotKey);
            ViewData["TimeRangeKey"] = new SelectList(_context.TimeRange, "TimeRangeKey", "TimeRangeKey", slotTimeRange.TimeRangeKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", slotTimeRange.TimeTypeKey);
            return View(slotTimeRange);
        }

        // GET: SlotTimeRanges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotTimeRange = await _context.SlotTimeRange.FindAsync(id);
            if (slotTimeRange == null)
            {
                return NotFound();
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotTimeRange.RecordStateKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotTimeRange.SlotKey);
            ViewData["TimeRangeKey"] = new SelectList(_context.TimeRange, "TimeRangeKey", "TimeRangeKey", slotTimeRange.TimeRangeKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", slotTimeRange.TimeTypeKey);
            return View(slotTimeRange);
        }

        // POST: SlotTimeRanges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlotTimeRangeId,SlotTimeRangeKey,SlotKey,TimeRangeKey,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] SlotTimeRange slotTimeRange)
        {
            if (id != slotTimeRange.SlotTimeRangeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slotTimeRange);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotTimeRangeExists(slotTimeRange.SlotTimeRangeId))
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
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotTimeRange.RecordStateKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotTimeRange.SlotKey);
            ViewData["TimeRangeKey"] = new SelectList(_context.TimeRange, "TimeRangeKey", "TimeRangeKey", slotTimeRange.TimeRangeKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", slotTimeRange.TimeTypeKey);
            return View(slotTimeRange);
        }

        // GET: SlotTimeRanges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotTimeRange = await _context.SlotTimeRange
                .Include(s => s.RecordStateKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .Include(s => s.TimeRangeKeyNavigation)
                .Include(s => s.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotTimeRangeId == id);
            if (slotTimeRange == null)
            {
                return NotFound();
            }

            return View(slotTimeRange);
        }

        // POST: SlotTimeRanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slotTimeRange = await _context.SlotTimeRange.FindAsync(id);
            _context.SlotTimeRange.Remove(slotTimeRange);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotTimeRangeExists(int id)
        {
            return _context.SlotTimeRange.Any(e => e.SlotTimeRangeId == id);
        }
    }
}
