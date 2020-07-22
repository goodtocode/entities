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
    public class TimeCyclesController : Controller
    {
        private readonly EntityDataContext _context;

        public TimeCyclesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: TimeCycles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeCycle.ToListAsync());
        }

        // GET: TimeCycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeCycle = await _context.TimeCycle
                .FirstOrDefaultAsync(m => m.TimeCycleId == id);
            if (timeCycle == null)
            {
                return NotFound();
            }

            return View(timeCycle);
        }

        // GET: TimeCycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeCycles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeCycleId,TimeCycleKey,TimeCycleName,TimeCycleDescription,Days,Interval,CreatedDate,ModifiedDate")] TimeCycle timeCycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeCycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeCycle);
        }

        // GET: TimeCycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeCycle = await _context.TimeCycle.FindAsync(id);
            if (timeCycle == null)
            {
                return NotFound();
            }
            return View(timeCycle);
        }

        // POST: TimeCycles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeCycleId,TimeCycleKey,TimeCycleName,TimeCycleDescription,Days,Interval,CreatedDate,ModifiedDate")] TimeCycle timeCycle)
        {
            if (id != timeCycle.TimeCycleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeCycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeCycleExists(timeCycle.TimeCycleId))
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
            return View(timeCycle);
        }

        // GET: TimeCycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeCycle = await _context.TimeCycle
                .FirstOrDefaultAsync(m => m.TimeCycleId == id);
            if (timeCycle == null)
            {
                return NotFound();
            }

            return View(timeCycle);
        }

        // POST: TimeCycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeCycle = await _context.TimeCycle.FindAsync(id);
            _context.TimeCycle.Remove(timeCycle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeCycleExists(int id)
        {
            return _context.TimeCycle.Any(e => e.TimeCycleId == id);
        }
    }
}
