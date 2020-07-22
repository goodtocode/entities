using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Shared.Models;

namespace GoodToCode.Chronology.Controllers
{
    public class TimeRangesController : Controller
    {
        private readonly EntityDataContext _context;

        public TimeRangesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: TimeRanges
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeRange.ToListAsync());
        }

        // GET: TimeRanges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRange = await _context.TimeRange
                .FirstOrDefaultAsync(m => m.TimeRangeId == id);
            if (timeRange == null)
            {
                return NotFound();
            }

            return View(timeRange);
        }

        // GET: TimeRanges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeRanges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeRangeId,TimeRangeKey,BeginDate,EndDate,CreatedDate")] TimeRange timeRange)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeRange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeRange);
        }

        // GET: TimeRanges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRange = await _context.TimeRange.FindAsync(id);
            if (timeRange == null)
            {
                return NotFound();
            }
            return View(timeRange);
        }

        // POST: TimeRanges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeRangeId,TimeRangeKey,BeginDate,EndDate,CreatedDate")] TimeRange timeRange)
        {
            if (id != timeRange.TimeRangeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeRange);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeRangeExists(timeRange.TimeRangeId))
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
            return View(timeRange);
        }

        // GET: TimeRanges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRange = await _context.TimeRange
                .FirstOrDefaultAsync(m => m.TimeRangeId == id);
            if (timeRange == null)
            {
                return NotFound();
            }

            return View(timeRange);
        }

        // POST: TimeRanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeRange = await _context.TimeRange.FindAsync(id);
            _context.TimeRange.Remove(timeRange);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeRangeExists(int id)
        {
            return _context.TimeRange.Any(e => e.TimeRangeId == id);
        }
    }
}
