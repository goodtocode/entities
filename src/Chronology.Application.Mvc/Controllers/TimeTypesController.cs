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
    public class TimeTypesController : Controller
    {
        private readonly EntityDataContext _context;

        public TimeTypesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: TimeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeType.ToListAsync());
        }

        // GET: TimeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeType = await _context.TimeType
                .FirstOrDefaultAsync(m => m.TimeTypeId == id);
            if (timeType == null)
            {
                return NotFound();
            }

            return View(timeType);
        }

        // GET: TimeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeTypeId,TimeTypeKey,TimeTypeName,TimeTypeDescription,TimeBehavior,CreatedDate,ModifiedDate")] TimeType timeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeType);
        }

        // GET: TimeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeType = await _context.TimeType.FindAsync(id);
            if (timeType == null)
            {
                return NotFound();
            }
            return View(timeType);
        }

        // POST: TimeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeTypeId,TimeTypeKey,TimeTypeName,TimeTypeDescription,TimeBehavior,CreatedDate,ModifiedDate")] TimeType timeType)
        {
            if (id != timeType.TimeTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeTypeExists(timeType.TimeTypeId))
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
            return View(timeType);
        }

        // GET: TimeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeType = await _context.TimeType
                .FirstOrDefaultAsync(m => m.TimeTypeId == id);
            if (timeType == null)
            {
                return NotFound();
            }

            return View(timeType);
        }

        // POST: TimeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeType = await _context.TimeType.FindAsync(id);
            _context.TimeType.Remove(timeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeTypeExists(int id)
        {
            return _context.TimeType.Any(e => e.TimeTypeId == id);
        }
    }
}
