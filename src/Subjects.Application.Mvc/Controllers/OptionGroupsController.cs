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
    public class OptionGroupsController : Controller
    {
        private readonly EntityDataContext _context;

        public OptionGroupsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: OptionGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.OptionGroup.ToListAsync());
        }

        // GET: OptionGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var optionGroup = await _context.OptionGroup
                .FirstOrDefaultAsync(m => m.OptionGroupId == id);
            if (optionGroup == null)
            {
                return NotFound();
            }

            return View(optionGroup);
        }

        // GET: OptionGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OptionGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OptionGroupId,OptionGroupKey,OptionGroupName,OptionGroupDescription,OptionGroupCode,CreatedDate,ModifiedDate")] OptionGroup optionGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(optionGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(optionGroup);
        }

        // GET: OptionGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var optionGroup = await _context.OptionGroup.FindAsync(id);
            if (optionGroup == null)
            {
                return NotFound();
            }
            return View(optionGroup);
        }

        // POST: OptionGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OptionGroupId,OptionGroupKey,OptionGroupName,OptionGroupDescription,OptionGroupCode,CreatedDate,ModifiedDate")] OptionGroup optionGroup)
        {
            if (id != optionGroup.OptionGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(optionGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OptionGroupExists(optionGroup.OptionGroupId))
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
            return View(optionGroup);
        }

        // GET: OptionGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var optionGroup = await _context.OptionGroup
                .FirstOrDefaultAsync(m => m.OptionGroupId == id);
            if (optionGroup == null)
            {
                return NotFound();
            }

            return View(optionGroup);
        }

        // POST: OptionGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var optionGroup = await _context.OptionGroup.FindAsync(id);
            _context.OptionGroup.Remove(optionGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OptionGroupExists(int id)
        {
            return _context.OptionGroup.Any(e => e.OptionGroupId == id);
        }
    }
}
