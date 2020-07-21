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
    public class ResourceTypesController : Controller
    {
        private readonly EntityDataContext _context;

        public ResourceTypesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: ResourceTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResourceType.ToListAsync());
        }

        // GET: ResourceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceType = await _context.ResourceType
                .FirstOrDefaultAsync(m => m.ResourceTypeId == id);
            if (resourceType == null)
            {
                return NotFound();
            }

            return View(resourceType);
        }

        // GET: ResourceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResourceTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourceTypeId,ResourceTypeKey,ResourceTypeName,ResourceTypeDescription,CreatedDate,ModifiedDate")] ResourceType resourceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resourceType);
        }

        // GET: ResourceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceType = await _context.ResourceType.FindAsync(id);
            if (resourceType == null)
            {
                return NotFound();
            }
            return View(resourceType);
        }

        // POST: ResourceTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResourceTypeId,ResourceTypeKey,ResourceTypeName,ResourceTypeDescription,CreatedDate,ModifiedDate")] ResourceType resourceType)
        {
            if (id != resourceType.ResourceTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceTypeExists(resourceType.ResourceTypeId))
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
            return View(resourceType);
        }

        // GET: ResourceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceType = await _context.ResourceType
                .FirstOrDefaultAsync(m => m.ResourceTypeId == id);
            if (resourceType == null)
            {
                return NotFound();
            }

            return View(resourceType);
        }

        // POST: ResourceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourceType = await _context.ResourceType.FindAsync(id);
            _context.ResourceType.Remove(resourceType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceTypeExists(int id)
        {
            return _context.ResourceType.Any(e => e.ResourceTypeId == id);
        }
    }
}
