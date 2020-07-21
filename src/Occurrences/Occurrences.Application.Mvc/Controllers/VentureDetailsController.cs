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
    public class VentureDetailsController : Controller
    {
        private readonly EntityDataContext _context;

        public VentureDetailsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: VentureDetails
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.VentureDetail.Include(v => v.DetailKeyNavigation).Include(v => v.VentureKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: VentureDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureDetail = await _context.VentureDetail
                .Include(v => v.DetailKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureDetailId == id);
            if (ventureDetail == null)
            {
                return NotFound();
            }

            return View(ventureDetail);
        }

        // GET: VentureDetails/Create
        public IActionResult Create()
        {
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData");
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription");
            return View();
        }

        // POST: VentureDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentureDetailId,VentureDetailKey,VentureKey,DetailKey,CreatedDate,ModifiedDate")] VentureDetail ventureDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventureDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData", ventureDetail.DetailKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureDetail.VentureKey);
            return View(ventureDetail);
        }

        // GET: VentureDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureDetail = await _context.VentureDetail.FindAsync(id);
            if (ventureDetail == null)
            {
                return NotFound();
            }
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData", ventureDetail.DetailKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureDetail.VentureKey);
            return View(ventureDetail);
        }

        // POST: VentureDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentureDetailId,VentureDetailKey,VentureKey,DetailKey,CreatedDate,ModifiedDate")] VentureDetail ventureDetail)
        {
            if (id != ventureDetail.VentureDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventureDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentureDetailExists(ventureDetail.VentureDetailId))
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
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData", ventureDetail.DetailKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureDetail.VentureKey);
            return View(ventureDetail);
        }

        // GET: VentureDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureDetail = await _context.VentureDetail
                .Include(v => v.DetailKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureDetailId == id);
            if (ventureDetail == null)
            {
                return NotFound();
            }

            return View(ventureDetail);
        }

        // POST: VentureDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventureDetail = await _context.VentureDetail.FindAsync(id);
            _context.VentureDetail.Remove(ventureDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentureDetailExists(int id)
        {
            return _context.VentureDetail.Any(e => e.VentureDetailId == id);
        }
    }
}
