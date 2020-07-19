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
    public class VentureSchedulesController : Controller
    {
        private readonly EntityDataContext _context;

        public VentureSchedulesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: VentureSchedules
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.VentureSchedule.Include(v => v.RecordStateKeyNavigation).Include(v => v.ScheduleKeyNavigation).Include(v => v.ScheduleTypeKeyNavigation).Include(v => v.VentureKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: VentureSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureSchedule = await _context.VentureSchedule
                .Include(v => v.RecordStateKeyNavigation)
                .Include(v => v.ScheduleKeyNavigation)
                .Include(v => v.ScheduleTypeKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureScheduleId == id);
            if (ventureSchedule == null)
            {
                return NotFound();
            }

            return View(ventureSchedule);
        }

        // GET: VentureSchedules/Create
        public IActionResult Create()
        {
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription");
            ViewData["ScheduleTypeKey"] = new SelectList(_context.ScheduleType, "ScheduleTypeKey", "ScheduleTypeDescription");
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription");
            return View();
        }

        // POST: VentureSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentureScheduleId,VentureScheduleKey,VentureKey,ScheduleKey,ScheduleTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] VentureSchedule ventureSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventureSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureSchedule.RecordStateKey);
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription", ventureSchedule.ScheduleKey);
            ViewData["ScheduleTypeKey"] = new SelectList(_context.ScheduleType, "ScheduleTypeKey", "ScheduleTypeDescription", ventureSchedule.ScheduleTypeKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureSchedule.VentureKey);
            return View(ventureSchedule);
        }

        // GET: VentureSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureSchedule = await _context.VentureSchedule.FindAsync(id);
            if (ventureSchedule == null)
            {
                return NotFound();
            }
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureSchedule.RecordStateKey);
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription", ventureSchedule.ScheduleKey);
            ViewData["ScheduleTypeKey"] = new SelectList(_context.ScheduleType, "ScheduleTypeKey", "ScheduleTypeDescription", ventureSchedule.ScheduleTypeKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureSchedule.VentureKey);
            return View(ventureSchedule);
        }

        // POST: VentureSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentureScheduleId,VentureScheduleKey,VentureKey,ScheduleKey,ScheduleTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] VentureSchedule ventureSchedule)
        {
            if (id != ventureSchedule.VentureScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventureSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentureScheduleExists(ventureSchedule.VentureScheduleId))
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
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureSchedule.RecordStateKey);
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription", ventureSchedule.ScheduleKey);
            ViewData["ScheduleTypeKey"] = new SelectList(_context.ScheduleType, "ScheduleTypeKey", "ScheduleTypeDescription", ventureSchedule.ScheduleTypeKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureSchedule.VentureKey);
            return View(ventureSchedule);
        }

        // GET: VentureSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureSchedule = await _context.VentureSchedule
                .Include(v => v.RecordStateKeyNavigation)
                .Include(v => v.ScheduleKeyNavigation)
                .Include(v => v.ScheduleTypeKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureScheduleId == id);
            if (ventureSchedule == null)
            {
                return NotFound();
            }

            return View(ventureSchedule);
        }

        // POST: VentureSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventureSchedule = await _context.VentureSchedule.FindAsync(id);
            _context.VentureSchedule.Remove(ventureSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentureScheduleExists(int id)
        {
            return _context.VentureSchedule.Any(e => e.VentureScheduleId == id);
        }
    }
}
