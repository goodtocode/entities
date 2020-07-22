using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodToCode.Shared.Models;

namespace GoodToCode.Chronology.Controllers
{
    public class SettingTypesController : Controller
    {
        private readonly EntityDataContext _context;

        public SettingTypesController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: SettingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SettingType.ToListAsync());
        }

        // GET: SettingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingType = await _context.SettingType
                .FirstOrDefaultAsync(m => m.SettingTypeId == id);
            if (settingType == null)
            {
                return NotFound();
            }

            return View(settingType);
        }

        // GET: SettingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SettingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SettingTypeId,SettingTypeKey,SettingTypeName,CreatedDate")] SettingType settingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(settingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(settingType);
        }

        // GET: SettingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingType = await _context.SettingType.FindAsync(id);
            if (settingType == null)
            {
                return NotFound();
            }
            return View(settingType);
        }

        // POST: SettingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SettingTypeId,SettingTypeKey,SettingTypeName,CreatedDate")] SettingType settingType)
        {
            if (id != settingType.SettingTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingTypeExists(settingType.SettingTypeId))
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
            return View(settingType);
        }

        // GET: SettingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingType = await _context.SettingType
                .FirstOrDefaultAsync(m => m.SettingTypeId == id);
            if (settingType == null)
            {
                return NotFound();
            }

            return View(settingType);
        }

        // POST: SettingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var settingType = await _context.SettingType.FindAsync(id);
            _context.SettingType.Remove(settingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettingTypeExists(int id)
        {
            return _context.SettingType.Any(e => e.SettingTypeId == id);
        }
    }
}
