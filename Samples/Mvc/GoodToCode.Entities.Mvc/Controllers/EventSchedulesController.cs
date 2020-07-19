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
    public class EventSchedulesController : Controller
    {
        private readonly EntityDataContext _context;

        public EventSchedulesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EventSchedules
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EventSchedule.Include(e => e.EventKeyNavigation).Include(e => e.RecordStateKeyNavigation).Include(e => e.ScheduleKeyNavigation).Include(e => e.ScheduleTypeKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EventSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSchedule = await _context.EventSchedule
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .Include(e => e.ScheduleKeyNavigation)
                .Include(e => e.ScheduleTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventScheduleId == id);
            if (eventSchedule == null)
            {
                return NotFound();
            }

            return View(eventSchedule);
        }

        // GET: EventSchedules/Create
        public IActionResult Create()
        {
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription");
            ViewData["ScheduleTypeKey"] = new SelectList(_context.ScheduleType, "ScheduleTypeKey", "ScheduleTypeDescription");
            return View();
        }

        // POST: EventSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventScheduleId,EventScheduleKey,EventKey,ScheduleKey,ScheduleTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EventSchedule eventSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventSchedule.EventKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventSchedule.RecordStateKey);
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription", eventSchedule.ScheduleKey);
            ViewData["ScheduleTypeKey"] = new SelectList(_context.ScheduleType, "ScheduleTypeKey", "ScheduleTypeDescription", eventSchedule.ScheduleTypeKey);
            return View(eventSchedule);
        }

        // GET: EventSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSchedule = await _context.EventSchedule.FindAsync(id);
            if (eventSchedule == null)
            {
                return NotFound();
            }
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventSchedule.EventKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventSchedule.RecordStateKey);
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription", eventSchedule.ScheduleKey);
            ViewData["ScheduleTypeKey"] = new SelectList(_context.ScheduleType, "ScheduleTypeKey", "ScheduleTypeDescription", eventSchedule.ScheduleTypeKey);
            return View(eventSchedule);
        }

        // POST: EventSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventScheduleId,EventScheduleKey,EventKey,ScheduleKey,ScheduleTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] EventSchedule eventSchedule)
        {
            if (id != eventSchedule.EventScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventScheduleExists(eventSchedule.EventScheduleId))
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
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventSchedule.EventKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventSchedule.RecordStateKey);
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription", eventSchedule.ScheduleKey);
            ViewData["ScheduleTypeKey"] = new SelectList(_context.ScheduleType, "ScheduleTypeKey", "ScheduleTypeDescription", eventSchedule.ScheduleTypeKey);
            return View(eventSchedule);
        }

        // GET: EventSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSchedule = await _context.EventSchedule
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .Include(e => e.ScheduleKeyNavigation)
                .Include(e => e.ScheduleTypeKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventScheduleId == id);
            if (eventSchedule == null)
            {
                return NotFound();
            }

            return View(eventSchedule);
        }

        // POST: EventSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventSchedule = await _context.EventSchedule.FindAsync(id);
            _context.EventSchedule.Remove(eventSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventScheduleExists(int id)
        {
            return _context.EventSchedule.Any(e => e.EventScheduleId == id);
        }
    }
}
