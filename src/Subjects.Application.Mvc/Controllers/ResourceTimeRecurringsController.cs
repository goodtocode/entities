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
    public class ResourceTimeRecurringsController : Controller
    {
        private readonly EntityDataContext _context;

        public ResourceTimeRecurringsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: ResourceTimeRecurrings
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.ResourceTimeRecurring.Include(r => r.RecordStateKeyNavigation).Include(r => r.ResourceKeyNavigation).Include(r => r.TimeRecurringKeyNavigation).Include(r => r.TimeTypeKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: ResourceTimeRecurrings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceTimeRecurring = await _context.ResourceTimeRecurring
                .Include(r => r.RecordStateKeyNavigation)
                .Include(r => r.ResourceKeyNavigation)
                .Include(r => r.TimeRecurringKeyNavigation)
                .Include(r => r.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.ResourceTimeRecurringId == id);
            if (resourceTimeRecurring == null)
            {
                return NotFound();
            }

            return View(resourceTimeRecurring);
        }

        // GET: ResourceTimeRecurrings/Create
        public IActionResult Create()
        {
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription");
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey");
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription");
            return View();
        }

        // POST: ResourceTimeRecurrings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourceTimeRecurringId,ResourceTimeRecurringKey,ResourceKey,TimeRecurringKey,DayName,TimeName,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] ResourceTimeRecurring resourceTimeRecurring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourceTimeRecurring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", resourceTimeRecurring.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", resourceTimeRecurring.ResourceKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", resourceTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", resourceTimeRecurring.TimeTypeKey);
            return View(resourceTimeRecurring);
        }

        // GET: ResourceTimeRecurrings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceTimeRecurring = await _context.ResourceTimeRecurring.FindAsync(id);
            if (resourceTimeRecurring == null)
            {
                return NotFound();
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", resourceTimeRecurring.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", resourceTimeRecurring.ResourceKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", resourceTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", resourceTimeRecurring.TimeTypeKey);
            return View(resourceTimeRecurring);
        }

        // POST: ResourceTimeRecurrings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResourceTimeRecurringId,ResourceTimeRecurringKey,ResourceKey,TimeRecurringKey,DayName,TimeName,TimeTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] ResourceTimeRecurring resourceTimeRecurring)
        {
            if (id != resourceTimeRecurring.ResourceTimeRecurringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourceTimeRecurring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceTimeRecurringExists(resourceTimeRecurring.ResourceTimeRecurringId))
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
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", resourceTimeRecurring.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", resourceTimeRecurring.ResourceKey);
            ViewData["TimeRecurringKey"] = new SelectList(_context.TimeRecurring, "TimeRecurringKey", "TimeRecurringKey", resourceTimeRecurring.TimeRecurringKey);
            ViewData["TimeTypeKey"] = new SelectList(_context.TimeType, "TimeTypeKey", "TimeTypeDescription", resourceTimeRecurring.TimeTypeKey);
            return View(resourceTimeRecurring);
        }

        // GET: ResourceTimeRecurrings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceTimeRecurring = await _context.ResourceTimeRecurring
                .Include(r => r.RecordStateKeyNavigation)
                .Include(r => r.ResourceKeyNavigation)
                .Include(r => r.TimeRecurringKeyNavigation)
                .Include(r => r.TimeTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.ResourceTimeRecurringId == id);
            if (resourceTimeRecurring == null)
            {
                return NotFound();
            }

            return View(resourceTimeRecurring);
        }

        // POST: ResourceTimeRecurrings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourceTimeRecurring = await _context.ResourceTimeRecurring.FindAsync(id);
            _context.ResourceTimeRecurring.Remove(resourceTimeRecurring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceTimeRecurringExists(int id)
        {
            return _context.ResourceTimeRecurring.Any(e => e.ResourceTimeRecurringId == id);
        }
    }
}
