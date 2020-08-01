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
    public class ResourcePersonsController : Controller
    {
        private readonly EntityDataContext _context;

        public ResourcePersonsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: ResourcePersons
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.ResourcePerson.Include(r => r.PersonKeyNavigation).Include(r => r.RecordStateKeyNavigation).Include(r => r.ResourceKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: ResourcePersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourcePerson = await _context.ResourcePerson
                .Include(r => r.PersonKeyNavigation)
                .Include(r => r.RecordStateKeyNavigation)
                .Include(r => r.ResourceKeyNavigation)
                .FirstOrDefaultAsync(m => m.ResourcePersonId == id);
            if (resourcePerson == null)
            {
                return NotFound();
            }

            return View(resourcePerson);
        }

        // GET: ResourcePersons/Create
        public IActionResult Create()
        {
            ViewData["PersonKey"] = new SelectList(_context.Person, "PersonKey", "FirstName");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription");
            return View();
        }

        // POST: ResourcePersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResourcePersonId,ResourcePersonKey,ResourceKey,PersonKey,RecordStateKey,CreatedDate,ModifiedDate")] ResourcePerson resourcePerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourcePerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonKey"] = new SelectList(_context.Person, "PersonKey", "FirstName", resourcePerson.PersonKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", resourcePerson.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", resourcePerson.ResourceKey);
            return View(resourcePerson);
        }

        // GET: ResourcePersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourcePerson = await _context.ResourcePerson.FindAsync(id);
            if (resourcePerson == null)
            {
                return NotFound();
            }
            ViewData["PersonKey"] = new SelectList(_context.Person, "PersonKey", "FirstName", resourcePerson.PersonKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", resourcePerson.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", resourcePerson.ResourceKey);
            return View(resourcePerson);
        }

        // POST: ResourcePersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResourcePersonId,ResourcePersonKey,ResourceKey,PersonKey,RecordStateKey,CreatedDate,ModifiedDate")] ResourcePerson resourcePerson)
        {
            if (id != resourcePerson.ResourcePersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourcePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourcePersonExists(resourcePerson.ResourcePersonId))
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
            ViewData["PersonKey"] = new SelectList(_context.Person, "PersonKey", "FirstName", resourcePerson.PersonKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", resourcePerson.RecordStateKey);
            ViewData["ResourceKey"] = new SelectList(_context.Resource, "ResourceKey", "ResourceDescription", resourcePerson.ResourceKey);
            return View(resourcePerson);
        }

        // GET: ResourcePersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourcePerson = await _context.ResourcePerson
                .Include(r => r.PersonKeyNavigation)
                .Include(r => r.RecordStateKeyNavigation)
                .Include(r => r.ResourceKeyNavigation)
                .FirstOrDefaultAsync(m => m.ResourcePersonId == id);
            if (resourcePerson == null)
            {
                return NotFound();
            }

            return View(resourcePerson);
        }

        // POST: ResourcePersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourcePerson = await _context.ResourcePerson.FindAsync(id);
            _context.ResourcePerson.Remove(resourcePerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourcePersonExists(int id)
        {
            return _context.ResourcePerson.Any(e => e.ResourcePersonId == id);
        }
    }
}
