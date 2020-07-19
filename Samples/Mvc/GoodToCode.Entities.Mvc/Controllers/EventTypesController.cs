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
    public class EventTypesController : Controller
    {
        private readonly EntityDataContext _context;

        public EventTypesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EventTypes
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EventType.Include(e => e.EventGroupKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EventTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = await _context.EventType
                .Include(e => e.EventGroupKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventTypeId == id);
            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        // GET: EventTypes/Create
        public IActionResult Create()
        {
            ViewData["EventGroupKey"] = new SelectList(_context.EventGroup, "EventGroupKey", "EventGroupDescription");
            return View();
        }

        // POST: EventTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventTypeId,EventTypeKey,EventGroupKey,EventTypeName,EventTypeDescription,CreatedDate,ModifiedDate")] EventType eventType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventGroupKey"] = new SelectList(_context.EventGroup, "EventGroupKey", "EventGroupDescription", eventType.EventGroupKey);
            return View(eventType);
        }

        // GET: EventTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = await _context.EventType.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }
            ViewData["EventGroupKey"] = new SelectList(_context.EventGroup, "EventGroupKey", "EventGroupDescription", eventType.EventGroupKey);
            return View(eventType);
        }

        // POST: EventTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventTypeId,EventTypeKey,EventGroupKey,EventTypeName,EventTypeDescription,CreatedDate,ModifiedDate")] EventType eventType)
        {
            if (id != eventType.EventTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTypeExists(eventType.EventTypeId))
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
            ViewData["EventGroupKey"] = new SelectList(_context.EventGroup, "EventGroupKey", "EventGroupDescription", eventType.EventGroupKey);
            return View(eventType);
        }

        // GET: EventTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventType = await _context.EventType
                .Include(e => e.EventGroupKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventTypeId == id);
            if (eventType == null)
            {
                return NotFound();
            }

            return View(eventType);
        }

        // POST: EventTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventType = await _context.EventType.FindAsync(id);
            _context.EventType.Remove(eventType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventTypeExists(int id)
        {
            return _context.EventType.Any(e => e.EventTypeId == id);
        }
    }
}
