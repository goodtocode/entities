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
    public class EntityDetailsController : Controller
    {
        private readonly EntityDataContext _context;

        public EntityDetailsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EntityDetails
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EntityDetail.Include(e => e.DetailKeyNavigation).Include(e => e.EntityKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EntityDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityDetail = await _context.EntityDetail
                .Include(e => e.DetailKeyNavigation)
                .Include(e => e.EntityKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityDetailId == id);
            if (entityDetail == null)
            {
                return NotFound();
            }

            return View(entityDetail);
        }

        // GET: EntityDetails/Create
        public IActionResult Create()
        {
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData");
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey");
            return View();
        }

        // POST: EntityDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntityDetailId,EntityDetailKey,EntityKey,DetailKey,CreatedDate,ModifiedDate")] EntityDetail entityDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData", entityDetail.DetailKey);
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityDetail.EntityKey);
            return View(entityDetail);
        }

        // GET: EntityDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityDetail = await _context.EntityDetail.FindAsync(id);
            if (entityDetail == null)
            {
                return NotFound();
            }
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData", entityDetail.DetailKey);
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityDetail.EntityKey);
            return View(entityDetail);
        }

        // POST: EntityDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntityDetailId,EntityDetailKey,EntityKey,DetailKey,CreatedDate,ModifiedDate")] EntityDetail entityDetail)
        {
            if (id != entityDetail.EntityDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityDetailExists(entityDetail.EntityDetailId))
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
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData", entityDetail.DetailKey);
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityDetail.EntityKey);
            return View(entityDetail);
        }

        // GET: EntityDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityDetail = await _context.EntityDetail
                .Include(e => e.DetailKeyNavigation)
                .Include(e => e.EntityKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityDetailId == id);
            if (entityDetail == null)
            {
                return NotFound();
            }

            return View(entityDetail);
        }

        // POST: EntityDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityDetail = await _context.EntityDetail.FindAsync(id);
            _context.EntityDetail.Remove(entityDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityDetailExists(int id)
        {
            return _context.EntityDetail.Any(e => e.EntityDetailId == id);
        }
    }
}
