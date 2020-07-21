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
    public class DetailTypesController : Controller
    {
        private readonly EntityDataContext _context;

        public DetailTypesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: DetailTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetailType.ToListAsync());
        }

        // GET: DetailTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailType = await _context.DetailType
                .FirstOrDefaultAsync(m => m.DetailTypeId == id);
            if (detailType == null)
            {
                return NotFound();
            }

            return View(detailType);
        }

        // GET: DetailTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetailTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailTypeId,DetailTypeKey,DetailTypeName,DetailTypeDescription,CreatedDate,ModifiedDate")] DetailType detailType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detailType);
        }

        // GET: DetailTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailType = await _context.DetailType.FindAsync(id);
            if (detailType == null)
            {
                return NotFound();
            }
            return View(detailType);
        }

        // POST: DetailTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailTypeId,DetailTypeKey,DetailTypeName,DetailTypeDescription,CreatedDate,ModifiedDate")] DetailType detailType)
        {
            if (id != detailType.DetailTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailTypeExists(detailType.DetailTypeId))
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
            return View(detailType);
        }

        // GET: DetailTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailType = await _context.DetailType
                .FirstOrDefaultAsync(m => m.DetailTypeId == id);
            if (detailType == null)
            {
                return NotFound();
            }

            return View(detailType);
        }

        // POST: DetailTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detailType = await _context.DetailType.FindAsync(id);
            _context.DetailType.Remove(detailType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailTypeExists(int id)
        {
            return _context.DetailType.Any(e => e.DetailTypeId == id);
        }
    }
}
