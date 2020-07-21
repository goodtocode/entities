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
    public class DetailsController : Controller
    {
        private readonly EntityDataContext _context;

        public DetailsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: Details
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.Detail.Include(d => d.DetailTypeKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .Include(d => d.DetailTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // GET: Details/Create
        public IActionResult Create()
        {
            ViewData["DetailTypeKey"] = new SelectList(_context.DetailType, "DetailTypeKey", "DetailTypeDescription");
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailId,DetailKey,DetailTypeKey,DetailData,CreatedDate,ModifiedDate")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DetailTypeKey"] = new SelectList(_context.DetailType, "DetailTypeKey", "DetailTypeDescription", detail.DetailTypeKey);
            return View(detail);
        }

        // GET: Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            ViewData["DetailTypeKey"] = new SelectList(_context.DetailType, "DetailTypeKey", "DetailTypeDescription", detail.DetailTypeKey);
            return View(detail);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailId,DetailKey,DetailTypeKey,DetailData,CreatedDate,ModifiedDate")] Detail detail)
        {
            if (id != detail.DetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailExists(detail.DetailId))
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
            ViewData["DetailTypeKey"] = new SelectList(_context.DetailType, "DetailTypeKey", "DetailTypeDescription", detail.DetailTypeKey);
            return View(detail);
        }

        // GET: Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .Include(d => d.DetailTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detail = await _context.Detail.FindAsync(id);
            _context.Detail.Remove(detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailExists(int id)
        {
            return _context.Detail.Any(e => e.DetailId == id);
        }
    }
}
