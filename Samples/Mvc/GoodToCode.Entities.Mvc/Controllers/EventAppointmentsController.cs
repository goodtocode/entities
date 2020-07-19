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
    public class EventAppointmentsController : Controller
    {
        private readonly EntityDataContext _context;

        public EventAppointmentsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EventAppointments
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EventAppointment.Include(e => e.AppointmentKeyNavigation).Include(e => e.EventKeyNavigation).Include(e => e.RecordStateKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EventAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventAppointment = await _context.EventAppointment
                .Include(e => e.AppointmentKeyNavigation)
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventAppointmentId == id);
            if (eventAppointment == null)
            {
                return NotFound();
            }

            return View(eventAppointment);
        }

        // GET: EventAppointments/Create
        public IActionResult Create()
        {
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription");
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            return View();
        }

        // POST: EventAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventAppointmentId,EventAppointmentKey,EventKey,AppointmentKey,RecordStateKey,CreatedDate,ModifiedDate")] EventAppointment eventAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription", eventAppointment.AppointmentKey);
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventAppointment.EventKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventAppointment.RecordStateKey);
            return View(eventAppointment);
        }

        // GET: EventAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventAppointment = await _context.EventAppointment.FindAsync(id);
            if (eventAppointment == null)
            {
                return NotFound();
            }
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription", eventAppointment.AppointmentKey);
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventAppointment.EventKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventAppointment.RecordStateKey);
            return View(eventAppointment);
        }

        // POST: EventAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventAppointmentId,EventAppointmentKey,EventKey,AppointmentKey,RecordStateKey,CreatedDate,ModifiedDate")] EventAppointment eventAppointment)
        {
            if (id != eventAppointment.EventAppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventAppointmentExists(eventAppointment.EventAppointmentId))
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
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription", eventAppointment.AppointmentKey);
            ViewData["EventKey"] = new SelectList(_context.Event, "EventKey", "EventDescription", eventAppointment.EventKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", eventAppointment.RecordStateKey);
            return View(eventAppointment);
        }

        // GET: EventAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventAppointment = await _context.EventAppointment
                .Include(e => e.AppointmentKeyNavigation)
                .Include(e => e.EventKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.EventAppointmentId == id);
            if (eventAppointment == null)
            {
                return NotFound();
            }

            return View(eventAppointment);
        }

        // POST: EventAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventAppointment = await _context.EventAppointment.FindAsync(id);
            _context.EventAppointment.Remove(eventAppointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventAppointmentExists(int id)
        {
            return _context.EventAppointment.Any(e => e.EventAppointmentId == id);
        }
    }
}
