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
    public class EntityOptionsController : Controller
    {
        private readonly EntityDataContext _context;

        public EntityOptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EntityOptions
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EntityOption.Include(e => e.OptionKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EntityOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityOption = await _context.EntityOption
                .Include(e => e.OptionKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityOptionId == id);
            if (entityOption == null)
            {
                return NotFound();
            }

            return View(entityOption);
        }

        // GET: EntityOptions/Create
        public IActionResult Create()
        {
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode");
            return View();
        }

        // POST: EntityOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntityOptionId,EntityOptionKey,EntityKey,OptionKey,CreatedDate,ModifiedDate")] EntityOption entityOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", entityOption.OptionKey);
            return View(entityOption);
        }

        // GET: EntityOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityOption = await _context.EntityOption.FindAsync(id);
            if (entityOption == null)
            {
                return NotFound();
            }
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", entityOption.OptionKey);
            return View(entityOption);
        }

        // POST: EntityOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntityOptionId,EntityOptionKey,EntityKey,OptionKey,CreatedDate,ModifiedDate")] EntityOption entityOption)
        {
            if (id != entityOption.EntityOptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityOptionExists(entityOption.EntityOptionId))
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
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", entityOption.OptionKey);
            return View(entityOption);
        }

        // GET: EntityOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityOption = await _context.EntityOption
                .Include(e => e.OptionKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityOptionId == id);
            if (entityOption == null)
            {
                return NotFound();
            }

            return View(entityOption);
        }

        // POST: EntityOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityOption = await _context.EntityOption.FindAsync(id);
            _context.EntityOption.Remove(entityOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityOptionExists(int id)
        {
            return _context.EntityOption.Any(e => e.EntityOptionId == id);
        }
    }
}
