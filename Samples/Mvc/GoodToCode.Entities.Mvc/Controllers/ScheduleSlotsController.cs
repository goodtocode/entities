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
    public class ScheduleSlotsController : Controller
    {
        private readonly EntityDataContext _context;

        public ScheduleSlotsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: ScheduleSlots
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.ScheduleSlot.Include(s => s.ScheduleKeyNavigation).Include(s => s.SlotKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: ScheduleSlots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleSlot = await _context.ScheduleSlot
                .Include(s => s.ScheduleKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .FirstOrDefaultAsync(m => m.ScheduleSlotId == id);
            if (scheduleSlot == null)
            {
                return NotFound();
            }

            return View(scheduleSlot);
        }

        // GET: ScheduleSlots/Create
        public IActionResult Create()
        {
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription");
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription");
            return View();
        }

        // POST: ScheduleSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleSlotId,ScheduleSlotKey,ScheduleKey,SlotKey,CreatedDate,ModifiedDate")] ScheduleSlot scheduleSlot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleSlot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription", scheduleSlot.ScheduleKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", scheduleSlot.SlotKey);
            return View(scheduleSlot);
        }

        // GET: ScheduleSlots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleSlot = await _context.ScheduleSlot.FindAsync(id);
            if (scheduleSlot == null)
            {
                return NotFound();
            }
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription", scheduleSlot.ScheduleKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", scheduleSlot.SlotKey);
            return View(scheduleSlot);
        }

        // POST: ScheduleSlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleSlotId,ScheduleSlotKey,ScheduleKey,SlotKey,CreatedDate,ModifiedDate")] ScheduleSlot scheduleSlot)
        {
            if (id != scheduleSlot.ScheduleSlotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleSlot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleSlotExists(scheduleSlot.ScheduleSlotId))
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
            ViewData["ScheduleKey"] = new SelectList(_context.Schedule, "ScheduleKey", "ScheduleDescription", scheduleSlot.ScheduleKey);
            ViewData["SlotKey"] = new SelectList(_context.Slot, "SlotKey", "SlotDescription", scheduleSlot.SlotKey);
            return View(scheduleSlot);
        }

        // GET: ScheduleSlots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleSlot = await _context.ScheduleSlot
                .Include(s => s.ScheduleKeyNavigation)
                .Include(s => s.SlotKeyNavigation)
                .FirstOrDefaultAsync(m => m.ScheduleSlotId == id);
            if (scheduleSlot == null)
            {
                return NotFound();
            }

            return View(scheduleSlot);
        }

        // POST: ScheduleSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduleSlot = await _context.ScheduleSlot.FindAsync(id);
            _context.ScheduleSlot.Remove(scheduleSlot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleSlotExists(int id)
        {
            return _context.ScheduleSlot.Any(e => e.ScheduleSlotId == id);
        }
    }
}
