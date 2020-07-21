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
    public class OptionsController : Controller
    {
        private readonly EntityDataContext _context;

        public OptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: Options
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.Option.Include(o => o.OptionGroupKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: Options/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Option
                .Include(o => o.OptionGroupKeyNavigation)
                .FirstOrDefaultAsync(m => m.OptionId == id);
            if (option == null)
            {
                return NotFound();
            }

            return View(option);
        }

        // GET: Options/Create
        public IActionResult Create()
        {
            ViewData["OptionGroupKey"] = new SelectList(_context.OptionGroup, "OptionGroupKey", "OptionGroupCode");
            return View();
        }

        // POST: Options/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OptionId,OptionKey,OptionGroupKey,OptionName,OptionDescription,OptionCode,SortOrder,CreatedDate,ModifiedDate")] Option option)
        {
            if (ModelState.IsValid)
            {
                _context.Add(option);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OptionGroupKey"] = new SelectList(_context.OptionGroup, "OptionGroupKey", "OptionGroupCode", option.OptionGroupKey);
            return View(option);
        }

        // GET: Options/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Option.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }
            ViewData["OptionGroupKey"] = new SelectList(_context.OptionGroup, "OptionGroupKey", "OptionGroupCode", option.OptionGroupKey);
            return View(option);
        }

        // POST: Options/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OptionId,OptionKey,OptionGroupKey,OptionName,OptionDescription,OptionCode,SortOrder,CreatedDate,ModifiedDate")] Option option)
        {
            if (id != option.OptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(option);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OptionExists(option.OptionId))
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
            ViewData["OptionGroupKey"] = new SelectList(_context.OptionGroup, "OptionGroupKey", "OptionGroupCode", option.OptionGroupKey);
            return View(option);
        }

        // GET: Options/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var option = await _context.Option
                .Include(o => o.OptionGroupKeyNavigation)
                .FirstOrDefaultAsync(m => m.OptionId == id);
            if (option == null)
            {
                return NotFound();
            }

            return View(option);
        }

        // POST: Options/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var option = await _context.Option.FindAsync(id);
            _context.Option.Remove(option);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OptionExists(int id)
        {
            return _context.Option.Any(e => e.OptionId == id);
        }
    }
}
