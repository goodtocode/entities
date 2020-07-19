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
    public class EntityTimeRecurringsController : Controller
    {
        private readonly EntityDataContext _context;

        public EntityTimeRecurringsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EntityTimeRecurrings
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EntityTimeRecurring.Include(e => e.EntityKeyNavigation).Include(e => e.RecordStateKeyNavigation).Include(e => e.TimeRecurringKeyNavigation).Include(e => e.TimeTypeKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EntityTimeRecurrings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityTimeRecurring = await _context.EntityTimeRecurring
                .Include(e => e.EntityKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .Include(e => e.TimeRecurringKeyNavigation)
                .Include(e => e.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityTimeRecurringId == id);
            if (entityTimeRecurring == null)
            {
                return NotFound();
            }

            return View(entityTimeRecurring);
        }

        // GET: EntityTimeRecurrings/Create
        public IActionResult Create()
        {
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey");
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription");
            return View();
        }

        // POST: EntityTimeRecurrings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntityTimeRecurringId,EntityTimeRecurringKey,EntityKey,TimeRecurringKey,DayName,TimeName,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EntityTimeRecurring entityTimeRecurring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityTimeRecurring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityTimeRecurring.EntityKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", entityTimeRecurring.RecordStateKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", entityTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", entityTimeRecurring.TimeTypeKey);
            return View(entityTimeRecurring);
        }

        // GET: EntityTimeRecurrings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityTimeRecurring = await _context.EntityTimeRecurring.FindAsync(id);
            if (entityTimeRecurring == null)
            {
                return NotFound();
            }
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityTimeRecurring.EntityKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", entityTimeRecurring.RecordStateKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", entityTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", entityTimeRecurring.TimeTypeKey);
            return View(entityTimeRecurring);
        }

        // POST: EntityTimeRecurrings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntityTimeRecurringId,EntityTimeRecurringKey,EntityKey,TimeRecurringKey,DayName,TimeName,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EntityTimeRecurring entityTimeRecurring)
        {
            if (id != entityTimeRecurring.EntityTimeRecurringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityTimeRecurring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityTimeRecurringExists(entityTimeRecurring.EntityTimeRecurringId))
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
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityTimeRecurring.EntityKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", entityTimeRecurring.RecordStateKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", entityTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", entityTimeRecurring.TimeTypeKey);
            return View(entityTimeRecurring);
        }

        // GET: EntityTimeRecurrings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityTimeRecurring = await _context.EntityTimeRecurring
                .Include(e => e.EntityKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .Include(e => e.TimeRecurringKeyNavigation)
                .Include(e => e.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityTimeRecurringId == id);
            if (entityTimeRecurring == null)
            {
                return NotFound();
            }

            return View(entityTimeRecurring);
        }

        // POST: EntityTimeRecurrings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityTimeRecurring = await _context.EntityTimeRecurring.FindAsync(id);
            _context.EntityTimeRecurring.Remove(entityTimeRecurring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityTimeRecurringExists(int id)
        {
            return _context.EntityTimeRecurring.Any(e => e.EntityTimeRecurringId == id);
        }
    }
}
