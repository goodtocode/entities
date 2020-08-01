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
    public class ResourceItemsController : Controller
    {
        private readonly EntityDataContext _context;

        public ResourceItemsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: ResourceItems
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.ResourceItem.Include(r => r.ItemKeyNavigation).Include(r => r.RecordStateKeyNavigation).Include(r => r.ResourceKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: ResourceItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceItem = await _context.ResourceItem
                .Include(r => r.ItemKeyNavigation)
                .Include(r => r.RecordStateKeyNavigation)
                .Include(r => r.ResourceKeyNavigation)
                .FirstOrDefaultAsync(m => m.ResourceItemId == id);
            if (resourceItem == null)
            {
                return NotFound();
            }

            return View(resourceItem);
        }

        // GET: ResourceItems/Create
        public IActionResult Create()
        {
            ViewData["ItemKey"] = new SelectList(_context.Item, "ItemKey", "ItemDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription");
            return View();
        }

        // POST: ResourceItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourceItemId,ResourceItemKey,ResourceKey,ItemKey,RecordStateKey,CreatedDate,ModifiedDate")] ResourceItem resourceItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourceItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemKey"] = new SelectList(_context.Item, "ItemKey", "ItemDescription", resourceItem.ItemKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", resourceItem.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", resourceItem.ResourceKey);
            return View(resourceItem);
        }

        // GET: ResourceItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceItem = await _context.ResourceItem.FindAsync(id);
            if (resourceItem == null)
            {
                return NotFound();
            }
            ViewData["ItemKey"] = new SelectList(_context.Item, "ItemKey", "ItemDescription", resourceItem.ItemKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", resourceItem.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", resourceItem.ResourceKey);
            return View(resourceItem);
        }

        // POST: ResourceItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResourceItemId,ResourceItemKey,ResourceKey,ItemKey,RecordStateKey,CreatedDate,ModifiedDate")] ResourceItem resourceItem)
        {
            if (id != resourceItem.ResourceItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourceItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceItemExists(resourceItem.ResourceItemId))
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
            ViewData["ItemKey"] = new SelectList(_context.Item, "ItemKey", "ItemDescription", resourceItem.ItemKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", resourceItem.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", resourceItem.ResourceKey);
            return View(resourceItem);
        }

        // GET: ResourceItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceItem = await _context.ResourceItem
                .Include(r => r.ItemKeyNavigation)
                .Include(r => r.RecordStateKeyNavigation)
                .Include(r => r.ResourceKeyNavigation)
                .FirstOrDefaultAsync(m => m.ResourceItemId == id);
            if (resourceItem == null)
            {
                return NotFound();
            }

            return View(resourceItem);
        }

        // POST: ResourceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourceItem = await _context.ResourceItem.FindAsync(id);
            _context.ResourceItem.Remove(resourceItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceItemExists(int id)
        {
            return _context.ResourceItem.Any(e => e.ResourceItemId == id);
        }
    }
}
