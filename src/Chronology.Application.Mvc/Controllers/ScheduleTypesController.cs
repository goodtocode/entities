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
    public class ScheduleTypesController : Controller
    {
        private readonly EntityDataContext _context;

        public ScheduleTypesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: ScheduleTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScheduleType.ToListAsync());
        }

        // GET: ScheduleTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleType = await _context.ScheduleType
                .FirstOrDefaultAsync(m => m.ScheduleTypeId == id);
            if (scheduleType == null)
            {
                return NotFound();
            }

            return View(scheduleType);
        }

        // GET: ScheduleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScheduleTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleTypeId,ScheduleTypeKey,ScheduleTypeName,ScheduleTypeDescription,CreatedDate,ModifiedDate")] ScheduleType scheduleType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleType);
        }

        // GET: ScheduleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleType = await _context.ScheduleType.FindAsync(id);
            if (scheduleType == null)
            {
                return NotFound();
            }
            return View(scheduleType);
        }

        // POST: ScheduleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleTypeId,ScheduleTypeKey,ScheduleTypeName,ScheduleTypeDescription,CreatedDate,ModifiedDate")] ScheduleType scheduleType)
        {
            if (id != scheduleType.ScheduleTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleTypeExists(scheduleType.ScheduleTypeId))
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
            return View(scheduleType);
        }

        // GET: ScheduleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleType = await _context.ScheduleType
                .FirstOrDefaultAsync(m => m.ScheduleTypeId == id);
            if (scheduleType == null)
            {
                return NotFound();
            }

            return View(scheduleType);
        }

        // POST: ScheduleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduleType = await _context.ScheduleType.FindAsync(id);
            _context.ScheduleType.Remove(scheduleType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleTypeExists(int id)
        {
            return _context.ScheduleType.Any(e => e.ScheduleTypeId == id);
        }
    }
}
