using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Shared.Models;

namespace GoodToCode.Subjects.Controllers
{
    public class EventEntityOptionsController : Controller
    {
        private readonly EntityDataContext _context;

        public EventEntityOptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EventEntityOptions
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EventEntityOption.Include(e => e.EntityKeyNavigation).Include(e => e.EventKeyNavigation).Include(e => e.OptionKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EventEntityOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventEntityOption = await _context.EventEntityOption
                .Include(e => e.EntityKeyNavigation)
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.OptionKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventEntityOptionId == id);
            if (eventEntityOption == null)
            {
                return NotFound();
            }

            return View(eventEntityOption);
        }

        // GET: EventEntityOptions/Create
        public IActionResult Create()
        {
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey");
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription");
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode");
            return View();
        }

        // POST: EventEntityOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventEntityOptionId,EventEntityOptionKey,OptionKey,EventKey,EntityKey,CreatedDate,ModifiedDate")] EventEntityOption eventEntityOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventEntityOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", eventEntityOption.EntityKey);
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventEntityOption.EventKey);
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", eventEntityOption.OptionKey);
            return View(eventEntityOption);
        }

        // GET: EventEntityOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventEntityOption = await _context.EventEntityOption.FindAsync(id);
            if (eventEntityOption == null)
            {
                return NotFound();
            }
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", eventEntityOption.EntityKey);
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventEntityOption.EventKey);
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", eventEntityOption.OptionKey);
            return View(eventEntityOption);
        }

        // POST: EventEntityOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventEntityOptionId,EventEntityOptionKey,OptionKey,EventKey,EntityKey,CreatedDate,ModifiedDate")] EventEntityOption eventEntityOption)
        {
            if (id != eventEntityOption.EventEntityOptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventEntityOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventEntityOptionExists(eventEntityOption.EventEntityOptionId))
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
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", eventEntityOption.EntityKey);
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventEntityOption.EventKey);
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", eventEntityOption.OptionKey);
            return View(eventEntityOption);
        }

        // GET: EventEntityOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventEntityOption = await _context.EventEntityOption
                .Include(e => e.EntityKeyNavigation)
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.OptionKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventEntityOptionId == id);
            if (eventEntityOption == null)
            {
                return NotFound();
            }

            return View(eventEntityOption);
        }

        // POST: EventEntityOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventEntityOption = await _context.EventEntityOption.FindAsync(id);
            _context.EventEntityOption.Remove(eventEntityOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventEntityOptionExists(int id)
        {
            return _context.EventEntityOption.Any(e => e.EventEntityOptionId == id);
        }
    }
}
