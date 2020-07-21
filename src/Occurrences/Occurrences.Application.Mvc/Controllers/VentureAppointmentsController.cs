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
    public class VentureAppointmentsController : Controller
    {
        private readonly EntityDataContext _context;

        public VentureAppointmentsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: VentureAppointments
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.VentureAppointment.Include(v => v.AppointmentKeyNavigation).Include(v => v.RecordStateKeyNavigation).Include(v => v.VentureKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: VentureAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureAppointment = await _context.VentureAppointment
                .Include(v => v.AppointmentKeyNavigation)
                .Include(v => v.RecordStateKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureAppointmentId == id);
            if (ventureAppointment == null)
            {
                return NotFound();
            }

            return View(ventureAppointment);
        }

        // GET: VentureAppointments/Create
        public IActionResult Create()
        {
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription");
            return View();
        }

        // POST: VentureAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentureAppointmentId,VentureAppointmentKey,VentureKey,AppointmentKey,RecordStateKey,CreatedDate,ModifiedDate")] VentureAppointment ventureAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventureAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription", ventureAppointment.AppointmentKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureAppointment.RecordStateKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureAppointment.VentureKey);
            return View(ventureAppointment);
        }

        // GET: VentureAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureAppointment = await _context.VentureAppointment.FindAsync(id);
            if (ventureAppointment == null)
            {
                return NotFound();
            }
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription", ventureAppointment.AppointmentKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureAppointment.RecordStateKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureAppointment.VentureKey);
            return View(ventureAppointment);
        }

        // POST: VentureAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentureAppointmentId,VentureAppointmentKey,VentureKey,AppointmentKey,RecordStateKey,CreatedDate,ModifiedDate")] VentureAppointment ventureAppointment)
        {
            if (id != ventureAppointment.VentureAppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventureAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentureAppointmentExists(ventureAppointment.VentureAppointmentId))
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
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription", ventureAppointment.AppointmentKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureAppointment.RecordStateKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureAppointment.VentureKey);
            return View(ventureAppointment);
        }

        // GET: VentureAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureAppointment = await _context.VentureAppointment
                .Include(v => v.AppointmentKeyNavigation)
                .Include(v => v.RecordStateKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureAppointmentId == id);
            if (ventureAppointment == null)
            {
                return NotFound();
            }

            return View(ventureAppointment);
        }

        // POST: VentureAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventureAppointment = await _context.VentureAppointment.FindAsync(id);
            _context.VentureAppointment.Remove(ventureAppointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentureAppointmentExists(int id)
        {
            return _context.VentureAppointment.Any(e => e.VentureAppointmentId == id);
        }
    }
}
