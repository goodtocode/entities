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
    public class VentureEntityOptionsController : Controller
    {
        private readonly EntityDataContext _context;

        public VentureEntityOptionsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: VentureEntityOptions
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.VentureEntityOption.Include(v => v.EntityKeyNavigation).Include(v => v.OptionKeyNavigation).Include(v => v.VentureKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: VentureEntityOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureEntityOption = await _context.VentureEntityOption
                .Include(v => v.EntityKeyNavigation)
                .Include(v => v.OptionKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureEntityOptionId == id);
            if (ventureEntityOption == null)
            {
                return NotFound();
            }

            return View(ventureEntityOption);
        }

        // GET: VentureEntityOptions/Create
        public IActionResult Create()
        {
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey");
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode");
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription");
            return View();
        }

        // POST: VentureEntityOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentureEntityOptionId,VentureEntityOptionKey,OptionKey,VentureKey,EntityKey,CreatedDate,ModifiedDate")] VentureEntityOption ventureEntityOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventureEntityOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", ventureEntityOption.EntityKey);
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", ventureEntityOption.OptionKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureEntityOption.VentureKey);
            return View(ventureEntityOption);
        }

        // GET: VentureEntityOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureEntityOption = await _context.VentureEntityOption.FindAsync(id);
            if (ventureEntityOption == null)
            {
                return NotFound();
            }
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", ventureEntityOption.EntityKey);
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", ventureEntityOption.OptionKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureEntityOption.VentureKey);
            return View(ventureEntityOption);
        }

        // POST: VentureEntityOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentureEntityOptionId,VentureEntityOptionKey,OptionKey,VentureKey,EntityKey,CreatedDate,ModifiedDate")] VentureEntityOption ventureEntityOption)
        {
            if (id != ventureEntityOption.VentureEntityOptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventureEntityOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentureEntityOptionExists(ventureEntityOption.VentureEntityOptionId))
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
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", ventureEntityOption.EntityKey);
            ViewData["OptionKey"] = new SelectList(_context.Option, "OptionKey", "OptionCode", ventureEntityOption.OptionKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureEntityOption.VentureKey);
            return View(ventureEntityOption);
        }

        // GET: VentureEntityOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureEntityOption = await _context.VentureEntityOption
                .Include(v => v.EntityKeyNavigation)
                .Include(v => v.OptionKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureEntityOptionId == id);
            if (ventureEntityOption == null)
            {
                return NotFound();
            }

            return View(ventureEntityOption);
        }

        // POST: VentureEntityOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventureEntityOption = await _context.VentureEntityOption.FindAsync(id);
            _context.VentureEntityOption.Remove(ventureEntityOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentureEntityOptionExists(int id)
        {
            return _context.VentureEntityOption.Any(e => e.VentureEntityOptionId == id);
        }
    }
}
