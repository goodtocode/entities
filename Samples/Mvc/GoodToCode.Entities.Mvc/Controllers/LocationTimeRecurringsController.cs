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
    public class LocationTimeRecurringsController : Controller
    {
        private readonly EntityDataContext _context;

        public LocationTimeRecurringsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: LocationTimeRecurrings
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.LocationTimeRecurring.Include(l => l.LocationKeyNavigation).Include(l => l.RecordStateKeyNavigation).Include(l => l.TimeRecurringKeyNavigation).Include(l => l.TimeTypeKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: LocationTimeRecurrings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationTimeRecurring = await _context.LocationTimeRecurring
                .Include(l => l.LocationKeyNavigation)
                .Include(l => l.RecordStateKeyNavigation)
                .Include(l => l.TimeRecurringKeyNavigation)
                .Include(l => l.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.LocationTimeRecurringId == id);
            if (locationTimeRecurring == null)
            {
                return NotFound();
            }

            return View(locationTimeRecurring);
        }

        // GET: LocationTimeRecurrings/Create
        public IActionResult Create()
        {
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey");
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription");
            return View();
        }

        // POST: LocationTimeRecurrings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationTimeRecurringId,LocationTimeRecurringKey,LocationKey,TimeRecurringKey,DayName,TimeName,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] LocationTimeRecurring locationTimeRecurring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationTimeRecurring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", locationTimeRecurring.LocationKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", locationTimeRecurring.RecordStateKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", locationTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", locationTimeRecurring.TimeTypeKey);
            return View(locationTimeRecurring);
        }

        // GET: LocationTimeRecurrings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationTimeRecurring = await _context.LocationTimeRecurring.FindAsync(id);
            if (locationTimeRecurring == null)
            {
                return NotFound();
            }
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", locationTimeRecurring.LocationKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", locationTimeRecurring.RecordStateKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", locationTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", locationTimeRecurring.TimeTypeKey);
            return View(locationTimeRecurring);
        }

        // POST: LocationTimeRecurrings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationTimeRecurringId,LocationTimeRecurringKey,LocationKey,TimeRecurringKey,DayName,TimeName,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] LocationTimeRecurring locationTimeRecurring)
        {
            if (id != locationTimeRecurring.LocationTimeRecurringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationTimeRecurring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationTimeRecurringExists(locationTimeRecurring.LocationTimeRecurringId))
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
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", locationTimeRecurring.LocationKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", locationTimeRecurring.RecordStateKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", locationTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", locationTimeRecurring.TimeTypeKey);
            return View(locationTimeRecurring);
        }

        // GET: LocationTimeRecurrings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationTimeRecurring = await _context.LocationTimeRecurring
                .Include(l => l.LocationKeyNavigation)
                .Include(l => l.RecordStateKeyNavigation)
                .Include(l => l.TimeRecurringKeyNavigation)
                .Include(l => l.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.LocationTimeRecurringId == id);
            if (locationTimeRecurring == null)
            {
                return NotFound();
            }

            return View(locationTimeRecurring);
        }

        // POST: LocationTimeRecurrings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationTimeRecurring = await _context.LocationTimeRecurring.FindAsync(id);
            _context.LocationTimeRecurring.Remove(locationTimeRecurring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationTimeRecurringExists(int id)
        {
            return _context.LocationTimeRecurring.Any(e => e.LocationTimeRecurringId == id);
        }
    }
}
