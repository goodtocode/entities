using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Shared.Models;

namespace GoodToCode.Locality.Controllers
{
    public class LocationAreasController : Controller
    {
        private readonly EntityDataContext _context;

        public LocationAreasController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: LocationAreas
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.LocationArea.Include(l => l.LocationKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: LocationAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationArea = await _context.LocationArea
                .Include(l => l.LocationKeyNavigation)
                .FirstOrDefaultAsync(m => m.LocationAreaId == id);
            if (locationArea == null)
            {
                return NotFound();
            }

            return View(locationArea);
        }

        // GET: LocationAreas/Create
        public IActionResult Create()
        {
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription");
            return View();
        }

        // POST: LocationAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationAreaId,LocationAreaKey,LocationKey,AreaKey,CreatedDate,ModifiedDate")] LocationArea locationArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", locationArea.LocationKey);
            return View(locationArea);
        }

        // GET: LocationAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationArea = await _context.LocationArea.FindAsync(id);
            if (locationArea == null)
            {
                return NotFound();
            }
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", locationArea.LocationKey);
            return View(locationArea);
        }

        // POST: LocationAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationAreaId,LocationAreaKey,LocationKey,AreaKey,CreatedDate,ModifiedDate")] LocationArea locationArea)
        {
            if (id != locationArea.LocationAreaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationAreaExists(locationArea.LocationAreaId))
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
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", locationArea.LocationKey);
            return View(locationArea);
        }

        // GET: LocationAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationArea = await _context.LocationArea
                .Include(l => l.LocationKeyNavigation)
                .FirstOrDefaultAsync(m => m.LocationAreaId == id);
            if (locationArea == null)
            {
                return NotFound();
            }

            return View(locationArea);
        }

        // POST: LocationAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationArea = await _context.LocationArea.FindAsync(id);
            _context.LocationArea.Remove(locationArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationAreaExists(int id)
        {
            return _context.LocationArea.Any(e => e.LocationAreaId == id);
        }
    }
}
