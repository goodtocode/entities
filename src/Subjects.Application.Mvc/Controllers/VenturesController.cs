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
    public class VenturesController : Controller
    {
        private readonly EntityDataContext _context;

        public VenturesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: Ventures
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.Venture.Include(v => v.RecordStateKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: Ventures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venture = await _context.Venture
                .Include(v => v.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureId == id);
            if (venture == null)
            {
                return NotFound();
            }

            return View(venture);
        }

        // GET: Ventures/Create
        public IActionResult Create()
        {
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            return View();
        }

        // POST: Ventures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentureId,VentureKey,VentureGroupKey,VentureTypeKey,VentureName,VentureDescription,VentureSlogan,RecordStateKey,CreatedDate,ModifiedDate")] Venture venture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", venture.RecordStateKey);
            return View(venture);
        }

        // GET: Ventures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venture = await _context.Venture.FindAsync(id);
            if (venture == null)
            {
                return NotFound();
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", venture.RecordStateKey);
            return View(venture);
        }

        // POST: Ventures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentureId,VentureKey,VentureGroupKey,VentureTypeKey,VentureName,VentureDescription,VentureSlogan,RecordStateKey,CreatedDate,ModifiedDate")] Venture venture)
        {
            if (id != venture.VentureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentureExists(venture.VentureId))
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
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", venture.RecordStateKey);
            return View(venture);
        }

        // GET: Ventures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venture = await _context.Venture
                .Include(v => v.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureId == id);
            if (venture == null)
            {
                return NotFound();
            }

            return View(venture);
        }

        // POST: Ventures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venture = await _context.Venture.FindAsync(id);
            _context.Venture.Remove(venture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentureExists(int id)
        {
            return _context.Venture.Any(e => e.VentureId == id);
        }
    }
}
