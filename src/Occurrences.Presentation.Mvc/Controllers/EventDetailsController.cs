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
    public class EventDetailsController : Controller
    {
        private readonly EntityDataContext _context;

        public EventDetailsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EventDetails
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EventDetail.Include(e => e.DetailKeyNavigation).Include(e => e.EventKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EventDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = await _context.EventDetail
                .Include(e => e.DetailKeyNavigation)
                .Include(e => e.EventKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventDetailId == id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            return View(eventDetail);
        }

        // GET: EventDetails/Create
        public IActionResult Create()
        {
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData");
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription");
            return View();
        }

        // POST: EventDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventDetailId,EventDetailKey,EventKey,DetailKey,CreatedDate,ModifiedDate")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData", eventDetail.DetailKey);
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventDetail.EventKey);
            return View(eventDetail);
        }

        // GET: EventDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = await _context.EventDetail.FindAsync(id);
            if (eventDetail == null)
            {
                return NotFound();
            }
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData", eventDetail.DetailKey);
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventDetail.EventKey);
            return View(eventDetail);
        }

        // POST: EventDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventDetailId,EventDetailKey,EventKey,DetailKey,CreatedDate,ModifiedDate")] EventDetail eventDetail)
        {
            if (id != eventDetail.EventDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventDetailExists(eventDetail.EventDetailId))
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
            ViewData["DetailKey"] = new SelectList(_context.Detail, "DetailKey", "DetailData", eventDetail.DetailKey);
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventDetail.EventKey);
            return View(eventDetail);
        }

        // GET: EventDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDetail = await _context.EventDetail
                .Include(e => e.DetailKeyNavigation)
                .Include(e => e.EventKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventDetailId == id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            return View(eventDetail);
        }

        // POST: EventDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventDetail = await _context.EventDetail.FindAsync(id);
            _context.EventDetail.Remove(eventDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventDetailExists(int id)
        {
            return _context.EventDetail.Any(e => e.EventDetailId == id);
        }
    }
}
