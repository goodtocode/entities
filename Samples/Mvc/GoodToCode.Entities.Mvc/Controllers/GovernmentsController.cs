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
    public class GovernmentsController : Controller
    {
        private readonly EntityDataContext _context;

        public GovernmentsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: Governments
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.Government.Include(g => g.GovernmentKeyNavigation).Include(g => g.RecordStateKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: Governments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var government = await _context.Government
                .Include(g => g.GovernmentKeyNavigation)
                .Include(g => g.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.GovernmentId == id);
            if (government == null)
            {
                return NotFound();
            }

            return View(government);
        }

        // GET: Governments/Create
        public IActionResult Create()
        {
            ViewData["GovernmentKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            return View();
        }

        // POST: Governments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GovernmentId,GovernmentKey,GovernmentName,RecordStateKey,CreatedDate,ModifiedDate")] Government government)
        {
            if (ModelState.IsValid)
            {
                _context.Add(government);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GovernmentKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", government.GovernmentKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", government.RecordStateKey);
            return View(government);
        }

        // GET: Governments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var government = await _context.Government.FindAsync(id);
            if (government == null)
            {
                return NotFound();
            }
            ViewData["GovernmentKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", government.GovernmentKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", government.RecordStateKey);
            return View(government);
        }

        // POST: Governments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GovernmentId,GovernmentKey,GovernmentName,RecordStateKey,CreatedDate,ModifiedDate")] Government government)
        {
            if (id != government.GovernmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(government);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GovernmentExists(government.GovernmentId))
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
            ViewData["GovernmentKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", government.GovernmentKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", government.RecordStateKey);
            return View(government);
        }

        // GET: Governments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var government = await _context.Government
                .Include(g => g.GovernmentKeyNavigation)
                .Include(g => g.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.GovernmentId == id);
            if (government == null)
            {
                return NotFound();
            }

            return View(government);
        }

        // POST: Governments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var government = await _context.Government.FindAsync(id);
            _context.Government.Remove(government);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GovernmentExists(int id)
        {
            return _context.Government.Any(e => e.GovernmentId == id);
        }
    }
}
