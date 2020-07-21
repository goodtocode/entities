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
    public class EventLocationsController : Controller
    {
        private readonly EntityDataContext _context;

        public EventLocationsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EventLocations
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EventLocation.Include(e => e.EventKeyNavigation).Include(e => e.LocationKeyNavigation).Include(e => e.LocationTypeKeyNavigation).Include(e => e.RecordStateKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EventLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLocation = await _context.EventLocation
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.LocationKeyNavigation)
                .Include(e => e.LocationTypeKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventLocationId == id);
            if (eventLocation == null)
            {
                return NotFound();
            }

            return View(eventLocation);
        }

        // GET: EventLocations/Create
        public IActionResult Create()
        {
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription");
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription");
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            return View();
        }

        // POST: EventLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventLocationId,EventLocationKey,EventKey,LocationKey,LocationTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EventLocation eventLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventLocation.EventKey);
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", eventLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", eventLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventLocation.RecordStateKey);
            return View(eventLocation);
        }

        // GET: EventLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLocation = await _context.EventLocation.FindAsync(id);
            if (eventLocation == null)
            {
                return NotFound();
            }
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventLocation.EventKey);
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", eventLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", eventLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventLocation.RecordStateKey);
            return View(eventLocation);
        }

        // POST: EventLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventLocationId,EventLocationKey,EventKey,LocationKey,LocationTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EventLocation eventLocation)
        {
            if (id != eventLocation.EventLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventLocationExists(eventLocation.EventLocationId))
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
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventLocation.EventKey);
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", eventLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", eventLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventLocation.RecordStateKey);
            return View(eventLocation);
        }

        // GET: EventLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLocation = await _context.EventLocation
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.LocationKeyNavigation)
                .Include(e => e.LocationTypeKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventLocationId == id);
            if (eventLocation == null)
            {
                return NotFound();
            }

            return View(eventLocation);
        }

        // POST: EventLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventLocation = await _context.EventLocation.FindAsync(id);
            _context.EventLocation.Remove(eventLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventLocationExists(int id)
        {
            return _context.EventLocation.Any(e => e.EventLocationId == id);
        }
    }
}
