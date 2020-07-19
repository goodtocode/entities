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
    public class EntityAppointmentsController : Controller
    {
        private readonly EntityDataContext _context;

        public EntityAppointmentsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: EntityAppointments
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.EntityAppointment.Include(e => e.AppointmentKeyNavigation).Include(e => e.EntityKeyNavigation).Include(e => e.RecordStateKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: EntityAppointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityAppointment = await _context.EntityAppointment
                .Include(e => e.AppointmentKeyNavigation)
                .Include(e => e.EntityKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityAppointmentId == id);
            if (entityAppointment == null)
            {
                return NotFound();
            }

            return View(entityAppointment);
        }

        // GET: EntityAppointments/Create
        public IActionResult Create()
        {
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription");
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            return View();
        }

        // POST: EntityAppointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntityAppointmentId,EntityAppointmentKey,EntityKey,AppointmentKey,RecordStateKey,CreatedDate,ModifiedDate")] EntityAppointment entityAppointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entityAppointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription", entityAppointment.AppointmentKey);
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityAppointment.EntityKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", entityAppointment.RecordStateKey);
            return View(entityAppointment);
        }

        // GET: EntityAppointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityAppointment = await _context.EntityAppointment.FindAsync(id);
            if (entityAppointment == null)
            {
                return NotFound();
            }
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription", entityAppointment.AppointmentKey);
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityAppointment.EntityKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", entityAppointment.RecordStateKey);
            return View(entityAppointment);
        }

        // POST: EntityAppointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntityAppointmentId,EntityAppointmentKey,EntityKey,AppointmentKey,RecordStateKey,CreatedDate,ModifiedDate")] EntityAppointment entityAppointment)
        {
            if (id != entityAppointment.EntityAppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityAppointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityAppointmentExists(entityAppointment.EntityAppointmentId))
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
            ViewData["AppointmentKey"] = new SelectList(_context.Appointment, "AppointmentKey", "AppointmentDescription", entityAppointment.AppointmentKey);
            ViewData["EntityKey"] = new SelectList(_context.Entity, "EntityKey", "EntityKey", entityAppointment.EntityKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", entityAppointment.RecordStateKey);
            return View(entityAppointment);
        }

        // GET: EntityAppointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityAppointment = await _context.EntityAppointment
                .Include(e => e.AppointmentKeyNavigation)
                .Include(e => e.EntityKeyNavigation)
                .Include(e => e.RecordStateKeyNavigation)
                .FirstOrDefaultAsync(m => m.EntityAppointmentId == id);
            if (entityAppointment == null)
            {
                return NotFound();
            }

            return View(entityAppointment);
        }

        // POST: EntityAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityAppointment = await _context.EntityAppointment.FindAsync(id);
            _context.EntityAppointment.Remove(entityAppointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntityAppointmentExists(int id)
        {
            return _context.EntityAppointment.Any(e => e.EntityAppointmentId == id);
        }
    }
}
