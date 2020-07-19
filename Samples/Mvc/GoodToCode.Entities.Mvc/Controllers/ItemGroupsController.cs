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
    public class ItemGroupsController : Controller
    {
        private readonly EntityDataContext _context;

        public ItemGroupsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: ItemGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemGroup.ToListAsync());
        }

        // GET: ItemGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemGroup = await _context.ItemGroup
                .FirstOrDefaultAsync(m => m.ItemGroupId == id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            return View(itemGroup);
        }

        // GET: ItemGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemGroupId,ItemGroupKey,ItemGroupName,ItemGroupDescription,CreatedDate,ModifiedDate")] ItemGroup itemGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemGroup);
        }

        // GET: ItemGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemGroup = await _context.ItemGroup.FindAsync(id);
            if (itemGroup == null)
            {
                return NotFound();
            }
            return View(itemGroup);
        }

        // POST: ItemGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemGroupId,ItemGroupKey,ItemGroupName,ItemGroupDescription,CreatedDate,ModifiedDate")] ItemGroup itemGroup)
        {
            if (id != itemGroup.ItemGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemGroupExists(itemGroup.ItemGroupId))
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
            return View(itemGroup);
        }

        // GET: ItemGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemGroup = await _context.ItemGroup
                .FirstOrDefaultAsync(m => m.ItemGroupId == id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            return View(itemGroup);
        }

        // POST: ItemGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemGroup = await _context.ItemGroup.FindAsync(id);
            _context.ItemGroup.Remove(itemGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemGroupExists(int id)
        {
            return _context.ItemGroup.Any(e => e.ItemGroupId == id);
        }
    }
}
