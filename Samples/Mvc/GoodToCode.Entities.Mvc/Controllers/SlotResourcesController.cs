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
    public class SlotResourcesController : Controller
    {
        private readonly EntityDataContext _context;

        public SlotResourcesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: SlotResources
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.SlotResource.Include(s => s.RecordStateKeyNavigation).Include(s => s.ResourceKeyNavigation).Include(s => s.ResourceTypeKeyNavigation).Include(s => s.SlotKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: SlotResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotResource = await _context.SlotResource
                .Include(s => s.RecordStateKeyNavigation)
                .Include(s => s.ResourceKeyNavigation)
                .Include(s => s.ResourceTypeKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotResourceId == id);
            if (slotResource == null)
            {
                return NotFound();
            }

            return View(slotResource);
        }

        // GET: SlotResources/Create
        public IActionResult Create()
        {
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription");
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription");
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription");
            return View();
        }

        // POST: SlotResources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlotResourceId,SlotResourceKey,SlotKey,ResourceKey,ResourceTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] SlotResource slotResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slotResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotResource.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", slotResource.ResourceKey);
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription", slotResource.ResourceTypeKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotResource.SlotKey);
            return View(slotResource);
        }

        // GET: SlotResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotResource = await _context.SlotResource.FindAsync(id);
            if (slotResource == null)
            {
                return NotFound();
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotResource.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", slotResource.ResourceKey);
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription", slotResource.ResourceTypeKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotResource.SlotKey);
            return View(slotResource);
        }

        // POST: SlotResources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlotResourceId,SlotResourceKey,SlotKey,ResourceKey,ResourceTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] SlotResource slotResource)
        {
            if (id != slotResource.SlotResourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slotResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlotResourceExists(slotResource.SlotResourceId))
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
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", slotResource.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", slotResource.ResourceKey);
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription", slotResource.ResourceTypeKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", slotResource.SlotKey);
            return View(slotResource);
        }

        // GET: SlotResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slotResource = await _context.SlotResource
                .Include(s => s.RecordStateKeyNavigation)
                .Include(s => s.ResourceKeyNavigation)
                .Include(s => s.ResourceTypeKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .FirstOrDefaultAsync(m => m.SlotResourceId == id);
            if (slotResource == null)
            {
                return NotFound();
            }

            return View(slotResource);
        }

        // POST: SlotResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slotResource = await _context.SlotResource.FindAsync(id);
            _context.SlotResource.Remove(slotResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlotResourceExists(int id)
        {
            return _context.SlotResource.Any(e => e.SlotResourceId == id);
        }
    }
}
