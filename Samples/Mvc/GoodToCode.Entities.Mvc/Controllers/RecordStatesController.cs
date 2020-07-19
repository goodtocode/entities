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
    public class RecordStatesController : Controller
    {
        private readonly EntityDataContext _context;

        public RecordStatesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: RecordStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecordState.ToListAsync());
        }

        // GET: RecordStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordState = await _context.RecordState
                .FirstOrDefaultAsync(m => m.RecordStateId == id);
            if (recordState == null)
            {
                return NotFound();
            }

            return View(recordState);
        }

        // GET: RecordStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecordStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordStateId,RecordStateKey,RecordStateName,CreatedDate,ModifiedDate")] RecordState recordState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recordState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recordState);
        }

        // GET: RecordStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordState = await _context.RecordState.FindAsync(id);
            if (recordState == null)
            {
                return NotFound();
            }
            return View(recordState);
        }

        // POST: RecordStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordStateId,RecordStateKey,RecordStateName,CreatedDate,ModifiedDate")] RecordState recordState)
        {
            if (id != recordState.RecordStateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recordState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordStateExists(recordState.RecordStateId))
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
            return View(recordState);
        }

        // GET: RecordStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordState = await _context.RecordState
                .FirstOrDefaultAsync(m => m.RecordStateId == id);
            if (recordState == null)
            {
                return NotFound();
            }

            return View(recordState);
        }

        // POST: RecordStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recordState = await _context.RecordState.FindAsync(id);
            _context.RecordState.Remove(recordState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordStateExists(int id)
        {
            return _context.RecordState.Any(e => e.RecordStateId == id);
        }
    }
}
