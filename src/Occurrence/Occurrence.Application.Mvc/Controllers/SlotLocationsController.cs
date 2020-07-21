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
    public class SlotLocationsController : Controller
    {
        private readonly EntityDataContext _context;

        public SlotLocationsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: SlotLocations
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.SlotLocation.Include(s => s.LocationKeyNavigation).Include(s => s.LocationTypeKeyNavigation).Include(s => s.RecordStateKeyNavigation).Include(s => s.SlotKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: SlotLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotLocation = await _context.SlotLocation
                .Include(s => s.LocationKeyNavigation)
                .Include(s => s.LocationTypeKeyNavigation)
                .Include(s => s.RecordStateKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotLocationId == id);
            if (slotLocation == null)
            {
                return NotFound();
            }

            return View(slotLocation);
        }

        // GET: SlotLocations/Create
        public IActionResult Create()
        {
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription");
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription");
            return View();
        }

        // POST: SlotLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlotLocationId,SlotLocationKey,SlotKey,LocationKey,LocationTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] SlotLocation slotLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slotLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", slotLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", slotLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotLocation.RecordStateKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotLocation.SlotKey);
            return View(slotLocation);
        }

        // GET: SlotLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotLocation = await _context.SlotLocation.FindAsync(id);
            if (slotLocation == null)
            {
                return NotFound();
            }
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", slotLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", slotLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotLocation.RecordStateKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotLocation.SlotKey);
            return View(slotLocation);
        }

        // POST: SlotLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlotLocationId,SlotLocationKey,SlotKey,LocationKey,LocationTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] SlotLocation slotLocation)
        {
            if (id != slotLocation.SlotLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slotLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotLocationExists(slotLocation.SlotLocationId))
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
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", slotLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", slotLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotLocation.RecordStateKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotLocation.SlotKey);
            return View(slotLocation);
        }

        // GET: SlotLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotLocation = await _context.SlotLocation
                .Include(s => s.LocationKeyNavigation)
                .Include(s => s.LocationTypeKeyNavigation)
                .Include(s => s.RecordStateKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotLocationId == id);
            if (slotLocation == null)
            {
                return NotFound();
            }

            return View(slotLocation);
        }

        // POST: SlotLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slotLocation = await _context.SlotLocation.FindAsync(id);
            _context.SlotLocation.Remove(slotLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotLocationExists(int id)
        {
            return _context.SlotLocation.Any(e => e.SlotLocationId == id);
        }
    }
}
