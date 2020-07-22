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
    public class EventOptionsController : Controller
    {
        private readonly EntityDataContext _context;

        public EventOptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EventOptions
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EventOption.Include(e => e.EventKeyNavigation).Include(e => e.OptionKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EventOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventOption = await _context.EventOption
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.OptionKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventOptionId == id);
            if (eventOption == null)
            {
                return NotFound();
            }

            return View(eventOption);
        }

        // GET: EventOptions/Create
        public IActionResult Create()
        {
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription");
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode");
            return View();
        }

        // POST: EventOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventOptionId,EventOptionKey,EventKey,OptionKey,CreatedDate,ModifiedDate")] EventOption eventOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventOption.EventKey);
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", eventOption.OptionKey);
            return View(eventOption);
        }

        // GET: EventOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventOption = await _context.EventOption.FindAsync(id);
            if (eventOption == null)
            {
                return NotFound();
            }
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventOption.EventKey);
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", eventOption.OptionKey);
            return View(eventOption);
        }

        // POST: EventOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventOptionId,EventOptionKey,EventKey,OptionKey,CreatedDate,ModifiedDate")] EventOption eventOption)
        {
            if (id != eventOption.EventOptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventOptionExists(eventOption.EventOptionId))
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
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventOption.EventKey);
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", eventOption.OptionKey);
            return View(eventOption);
        }

        // GET: EventOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventOption = await _context.EventOption
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.OptionKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventOptionId == id);
            if (eventOption == null)
            {
                return NotFound();
            }

            return View(eventOption);
        }

        // POST: EventOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventOption = await _context.EventOption.FindAsync(id);
            _context.EventOption.Remove(eventOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventOptionExists(int id)
        {
            return _context.EventOption.Any(e => e.EventOptionId == id);
        }
    }
}
