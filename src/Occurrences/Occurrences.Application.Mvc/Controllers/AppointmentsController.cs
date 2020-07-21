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
    public class AppointmentsController : Controller
    {
        private readonly EntityDataContext _context;

        public AppointmentsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.Appointment.Include(a => a.RecordStateKeyNavigation).Include(a => a.SlotLocationKeyNavigation).Include(a => a.SlotResourceKeyNavigation).Include(a => a.TimeRangeKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.RecordStateKeyNavigation)
                .Include(a => a.SlotLocationKeyNavigation)
                .Include(a => a.SlotResourceKeyNavigation)
                .Include(a => a.TimeRangeKeyNavigation)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["SlotLocationKey"] = new SelectList(_context.SlotLocation, "SlotLocationKey", "SlotLocationKey");
            ViewData["SlotResourceKey"] = new SelectList(_context.SlotResource, "SlotResourceKey", "SlotResourceKey");
            ViewData["TimeRangeKey"] = new SelectList(_context.TimeRange, "TimeRangeKey", "TimeRangeKey");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,AppointmentKey,AppointmentName,AppointmentDescription,SlotLocationKey,SlotResourceKey,TimeRangeKey,RecordStateKey,CreatedDate,ModifiedDate")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", appointment.RecordStateKey);
            ViewData["SlotLocationKey"] = new SelectList(_context.SlotLocation, "SlotLocationKey", "SlotLocationKey", appointment.SlotLocationKey);
            ViewData["SlotResourceKey"] = new SelectList(_context.SlotResource, "SlotResourceKey", "SlotResourceKey", appointment.SlotResourceKey);
            ViewData["TimeRangeKey"] = new SelectList(_context.TimeRange, "TimeRangeKey", "TimeRangeKey", appointment.TimeRangeKey);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", appointment.RecordStateKey);
            ViewData["SlotLocationKey"] = new SelectList(_context.SlotLocation, "SlotLocationKey", "SlotLocationKey", appointment.SlotLocationKey);
            ViewData["SlotResourceKey"] = new SelectList(_context.SlotResource, "SlotResourceKey", "SlotResourceKey", appointment.SlotResourceKey);
            ViewData["TimeRangeKey"] = new SelectList(_context.TimeRange, "TimeRangeKey", "TimeRangeKey", appointment.TimeRangeKey);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,AppointmentKey,AppointmentName,AppointmentDescription,SlotLocationKey,SlotResourceKey,TimeRangeKey,RecordStateKey,CreatedDate,ModifiedDate")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", appointment.RecordStateKey);
            ViewData["SlotLocationKey"] = new SelectList(_context.SlotLocation, "SlotLocationKey", "SlotLocationKey", appointment.SlotLocationKey);
            ViewData["SlotResourceKey"] = new SelectList(_context.SlotResource, "SlotResourceKey", "SlotResourceKey", appointment.SlotResourceKey);
            ViewData["TimeRangeKey"] = new SelectList(_context.TimeRange, "TimeRangeKey", "TimeRangeKey", appointment.TimeRangeKey);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.RecordStateKeyNavigation)
                .Include(a => a.SlotLocationKeyNavigation)
                .Include(a => a.SlotResourceKeyNavigation)
                .Include(a => a.TimeRangeKeyNavigation)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.AppointmentId == id);
        }
    }
}
