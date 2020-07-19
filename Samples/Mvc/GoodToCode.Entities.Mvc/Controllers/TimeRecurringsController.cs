using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Entities.Web.Models;

namespace GoodToCode.Entities.Web.Controllers
{
    public class TimeRecurringsController : Controller
    {
        private readonly EntityDataContext _context;

        public TimeRecurringsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: TimeRecurrings
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.TimeRecurring.Include(t => t.TimeCycleKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: TimeRecurrings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRecurring = await _context.TimeRecurring
                .Include(t => t.TimeCycleKeyNavigation)
                .FirstOrDefaultAsync(m => m.TimeRecurringId == id);
            if (timeRecurring == null)
            {
                return NotFound();
            }

            return View(timeRecurring);
        }

        // GET: TimeRecurrings/Create
        public IActionResult Create()
        {
            ViewData["TimeCycleKey"] = new SelectList(_context.TimeCycle, "TimeCycleKey", "TimeCycleDescription");
            return View();
        }

        // POST: TimeRecurrings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeRecurringId,TimeRecurringKey,BeginDay,EndDay,BeginTime,EndTime,Interval,TimeCycleKey,CreatedDate")] TimeRecurring timeRecurring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeRecurring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TimeCycleKey"] = new SelectList(_context.TimeCycle, "TimeCycleKey", "TimeCycleDescription", timeRecurring.TimeCycleKey);
            return View(timeRecurring);
        }

        // GET: TimeRecurrings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRecurring = await _context.TimeRecurring.FindAsync(id);
            if (timeRecurring == null)
            {
                return NotFound();
            }
            ViewData["TimeCycleKey"] = new SelectList(_context.TimeCycle, "TimeCycleKey", "TimeCycleDescription", timeRecurring.TimeCycleKey);
            return View(timeRecurring);
        }

        // POST: TimeRecurrings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeRecurringId,TimeRecurringKey,BeginDay,EndDay,BeginTime,EndTime,Interval,TimeCycleKey,CreatedDate")] TimeRecurring timeRecurring)
        {
            if (id != timeRecurring.TimeRecurringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeRecurring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeRecurringExists(timeRecurring.TimeRecurringId))
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
            ViewData["TimeCycleKey"] = new SelectList(_context.TimeCycle, "TimeCycleKey", "TimeCycleDescription", timeRecurring.TimeCycleKey);
            return View(timeRecurring);
        }

        // GET: TimeRecurrings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRecurring = await _context.TimeRecurring
                .Include(t => t.TimeCycleKeyNavigation)
                .FirstOrDefaultAsync(m => m.TimeRecurringId == id);
            if (timeRecurring == null)
            {
                return NotFound();
            }

            return View(timeRecurring);
        }

        // POST: TimeRecurrings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeRecurring = await _context.TimeRecurring.FindAsync(id);
            _context.TimeRecurring.Remove(timeRecurring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeRecurringExists(int id)
        {
            return _context.TimeRecurring.Any(e => e.TimeRecurringId == id);
        }
    }
}
