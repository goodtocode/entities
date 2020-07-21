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
    public class VentureResourcesController : Controller
    {
        private readonly EntityDataContext _context;

        public VentureResourcesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: VentureResources
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.VentureResource.Include(v => v.RecordStateKeyNavigation).Include(v => v.ResourceKeyNavigation).Include(v => v.ResourceTypeKeyNavigation).Include(v => v.VentureKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: VentureResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureResource = await _context.VentureResource
                .Include(v => v.RecordStateKeyNavigation)
                .Include(v => v.ResourceKeyNavigation)
                .Include(v => v.ResourceTypeKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureResourceId == id);
            if (ventureResource == null)
            {
                return NotFound();
            }

            return View(ventureResource);
        }

        // GET: VentureResources/Create
        public IActionResult Create()
        {
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription");
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription");
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription");
            return View();
        }

        // POST: VentureResources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentureResourceId,VentureResourceKey,VentureKey,ResourceKey,ResourceTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] VentureResource ventureResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventureResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureResource.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", ventureResource.ResourceKey);
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription", ventureResource.ResourceTypeKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureResource.VentureKey);
            return View(ventureResource);
        }

        // GET: VentureResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureResource = await _context.VentureResource.FindAsync(id);
            if (ventureResource == null)
            {
                return NotFound();
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureResource.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", ventureResource.ResourceKey);
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription", ventureResource.ResourceTypeKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureResource.VentureKey);
            return View(ventureResource);
        }

        // POST: VentureResources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentureResourceId,VentureResourceKey,VentureKey,ResourceKey,ResourceTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] VentureResource ventureResource)
        {
            if (id != ventureResource.VentureResourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventureResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentureResourceExists(ventureResource.VentureResourceId))
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
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureResource.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", ventureResource.ResourceKey);
            ViewData["ResourceTypeKey"] = new SelectList(_context.ResourceType, "ResourceTypeKey", "ResourceTypeDescription", ventureResource.ResourceTypeKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureResource.VentureKey);
            return View(ventureResource);
        }

        // GET: VentureResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureResource = await _context.VentureResource
                .Include(v => v.RecordStateKeyNavigation)
                .Include(v => v.ResourceKeyNavigation)
                .Include(v => v.ResourceTypeKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureResourceId == id);
            if (ventureResource == null)
            {
                return NotFound();
            }

            return View(ventureResource);
        }

        // POST: VentureResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventureResource = await _context.VentureResource.FindAsync(id);
            _context.VentureResource.Remove(ventureResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentureResourceExists(int id)
        {
            return _context.VentureResource.Any(e => e.VentureResourceId == id);
        }
    }
}
