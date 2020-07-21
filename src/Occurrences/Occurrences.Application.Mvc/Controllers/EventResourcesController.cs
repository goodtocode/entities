using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Subjects.Controllers
{
    public class EventResourcesController : Controller
    {
        private readonly EntityDataContext _context;

        public EventResourcesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EventResources
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EventResource.Include(e => e.EventKeyNavigation).Include(e => e.RecordStateKeyNavigation).Include(e => e.ResourceKeyNavigation).Include(e => e.ResourceTypeKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EventResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventResource = await _context.EventResource
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .Include(e => e.ResourceKeyNavigation)
                .Include(e => e.ResourceTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventResourceId == id);
            if (eventResource == null)
            {
                return NotFound();
            }

            return View(eventResource);
        }

        // GET: EventResources/Create
        public IActionResult Create()
        {
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription");
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription");
            return View();
        }

        // POST: EventResources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventResourceId,EventResourceKey,EventKey,ResourceKey,ResourceTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EventResource eventResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventResource.EventKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventResource.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", eventResource.ResourceKey);
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription", eventResource.ResourceTypeKey);
            return View(eventResource);
        }

        // GET: EventResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventResource = await _context.EventResource.FindAsync(id);
            if (eventResource == null)
            {
                return NotFound();
            }
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventResource.EventKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventResource.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", eventResource.ResourceKey);
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription", eventResource.ResourceTypeKey);
            return View(eventResource);
        }

        // POST: EventResources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventResourceId,EventResourceKey,EventKey,ResourceKey,ResourceTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EventResource eventResource)
        {
            if (id != eventResource.EventResourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventResourceExists(eventResource.EventResourceId))
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
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventResource.EventKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventResource.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", eventResource.ResourceKey);
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription", eventResource.ResourceTypeKey);
            return View(eventResource);
        }

        // GET: EventResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventResource = await _context.EventResource
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .Include(e => e.ResourceKeyNavigation)
                .Include(e => e.ResourceTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventResourceId == id);
            if (eventResource == null)
            {
                return NotFound();
            }

            return View(eventResource);
        }

        // POST: EventResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventResource = await _context.EventResource.FindAsync(id);
            _context.EventResource.Remove(eventResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventResourceExists(int id)
        {
            return _context.EventResource.Any(e => e.EventResourceId == id);
        }
    }
}
