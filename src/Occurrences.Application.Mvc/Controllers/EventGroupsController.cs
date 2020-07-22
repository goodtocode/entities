using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Shared.Models;

namespace GoodToCode.Subjects.Controllers
{
    public class EventGroupsController : Controller
    {
        private readonly EntityDataContext _context;

        public EventGroupsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EventGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventGroup.ToListAsync());
        }

        // GET: EventGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventGroup = await _context.EventGroup
                .FirstOrDefaultAsync(m => m.EventGroupId == id);
            if (eventGroup == null)
            {
                return NotFound();
            }

            return View(eventGroup);
        }

        // GET: EventGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventGroupId,EventGroupKey,EventGroupName,EventGroupDescription,CreatedDate,ModifiedDate")] EventGroup eventGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventGroup);
        }

        // GET: EventGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventGroup = await _context.EventGroup.FindAsync(id);
            if (eventGroup == null)
            {
                return NotFound();
            }
            return View(eventGroup);
        }

        // POST: EventGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventGroupId,EventGroupKey,EventGroupName,EventGroupDescription,CreatedDate,ModifiedDate")] EventGroup eventGroup)
        {
            if (id != eventGroup.EventGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventGroupExists(eventGroup.EventGroupId))
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
            return View(eventGroup);
        }

        // GET: EventGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventGroup = await _context.EventGroup
                .FirstOrDefaultAsync(m => m.EventGroupId == id);
            if (eventGroup == null)
            {
                return NotFound();
            }

            return View(eventGroup);
        }

        // POST: EventGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventGroup = await _context.EventGroup.FindAsync(id);
            _context.EventGroup.Remove(eventGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventGroupExists(int id)
        {
            return _context.EventGroup.Any(e => e.EventGroupId == id);
        }
    }
}
