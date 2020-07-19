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
    public class VentureOptionsController : Controller
    {
        private readonly EntityDataContext _context;

        public VentureOptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: VentureOptions
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.VentureOption.Include(v => v.OptionKeyNavigation).Include(v => v.VentureKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: VentureOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureOption = await _context.VentureOption
                .Include(v => v.OptionKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureOptionId == id);
            if (ventureOption == null)
            {
                return NotFound();
            }

            return View(ventureOption);
        }

        // GET: VentureOptions/Create
        public IActionResult Create()
        {
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode");
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription");
            return View();
        }

        // POST: VentureOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentureOptionId,VentureOptionKey,VentureKey,OptionKey,CreatedDate,ModifiedDate")] VentureOption ventureOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventureOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", ventureOption.OptionKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureOption.VentureKey);
            return View(ventureOption);
        }

        // GET: VentureOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureOption = await _context.VentureOption.FindAsync(id);
            if (ventureOption == null)
            {
                return NotFound();
            }
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", ventureOption.OptionKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureOption.VentureKey);
            return View(ventureOption);
        }

        // POST: VentureOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentureOptionId,VentureOptionKey,VentureKey,OptionKey,CreatedDate,ModifiedDate")] VentureOption ventureOption)
        {
            if (id != ventureOption.VentureOptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventureOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentureOptionExists(ventureOption.VentureOptionId))
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
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", ventureOption.OptionKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureOption.VentureKey);
            return View(ventureOption);
        }

        // GET: VentureOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureOption = await _context.VentureOption
                .Include(v => v.OptionKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureOptionId == id);
            if (ventureOption == null)
            {
                return NotFound();
            }

            return View(ventureOption);
        }

        // POST: VentureOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventureOption = await _context.VentureOption.FindAsync(id);
            _context.VentureOption.Remove(ventureOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentureOptionExists(int id)
        {
            return _context.VentureOption.Any(e => e.VentureOptionId == id);
        }
    }
}
