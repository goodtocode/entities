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
    public class EntityLocationsController : Controller
    {
        private readonly EntityDataContext _context;

        public EntityLocationsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EntityLocations
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EntityLocation.Include(e => e.EntityKeyNavigation).Include(e => e.LocationKeyNavigation).Include(e => e.LocationTypeKeyNavigation).Include(e => e.RecordStateKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EntityLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityLocation = await _context.EntityLocation
                .Include(e => e.EntityKeyNavigation)
                .Include(e => e.LocationKeyNavigation)
                .Include(e => e.LocationTypeKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityLocationId == id);
            if (entityLocation == null)
            {
                return NotFound();
            }

            return View(entityLocation);
        }

        // GET: EntityLocations/Create
        public IActionResult Create()
        {
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey");
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription");
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            return View();
        }

        // POST: EntityLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntityLocationId,EntityLocationKey,EntityKey,LocationKey,LocationTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EntityLocation entityLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityLocation.EntityKey);
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", entityLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", entityLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", entityLocation.RecordStateKey);
            return View(entityLocation);
        }

        // GET: EntityLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityLocation = await _context.EntityLocation.FindAsync(id);
            if (entityLocation == null)
            {
                return NotFound();
            }
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityLocation.EntityKey);
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", entityLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", entityLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", entityLocation.RecordStateKey);
            return View(entityLocation);
        }

        // POST: EntityLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntityLocationId,EntityLocationKey,EntityKey,LocationKey,LocationTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EntityLocation entityLocation)
        {
            if (id != entityLocation.EntityLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityLocationExists(entityLocation.EntityLocationId))
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
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityLocation.EntityKey);
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", entityLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", entityLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", entityLocation.RecordStateKey);
            return View(entityLocation);
        }

        // GET: EntityLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityLocation = await _context.EntityLocation
                .Include(e => e.EntityKeyNavigation)
                .Include(e => e.LocationKeyNavigation)
                .Include(e => e.LocationTypeKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityLocationId == id);
            if (entityLocation == null)
            {
                return NotFound();
            }

            return View(entityLocation);
        }

        // POST: EntityLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityLocation = await _context.EntityLocation.FindAsync(id);
            _context.EntityLocation.Remove(entityLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityLocationExists(int id)
        {
            return _context.EntityLocation.Any(e => e.EntityLocationId == id);
        }
    }
}
