using GoodToCode.Subjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Controllers
{
    public class VentureLocationsController : Controller
    {
        private readonly EntityDataContext _context;

        public VentureLocationsController(EntityDataContext context)
        {
            _context = context;
        }

        // GET: VentureLocations
        public async Task<IActionResult> Index()
        {
            var entityDataContext = _context.VentureLocation.Include(v => v.LocationKeyNavigation).Include(v => v.LocationTypeKeyNavigation).Include(v => v.RecordStateKeyNavigation).Include(v => v.VentureKeyNavigation);
            return View(await entityDataContext.ToListAsync());
        }

        // GET: VentureLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureLocation = await _context.VentureLocation
                .Include(v => v.LocationKeyNavigation)
                .Include(v => v.LocationTypeKeyNavigation)
                .Include(v => v.RecordStateKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureLocationId == id);
            if (ventureLocation == null)
            {
                return NotFound();
            }

            return View(ventureLocation);
        }

        // GET: VentureLocations/Create
        public IActionResult Create()
        {
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription");
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription");
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName");
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription");
            return View();
        }

        // POST: VentureLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentureLocationId,VentureLocationKey,VentureKey,LocationKey,LocationTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] VentureLocation ventureLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventureLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", ventureLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", ventureLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureLocation.RecordStateKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureLocation.VentureKey);
            return View(ventureLocation);
        }

        // GET: VentureLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureLocation = await _context.VentureLocation.FindAsync(id);
            if (ventureLocation == null)
            {
                return NotFound();
            }
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", ventureLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", ventureLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureLocation.RecordStateKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureLocation.VentureKey);
            return View(ventureLocation);
        }

        // POST: VentureLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentureLocationId,VentureLocationKey,VentureKey,LocationKey,LocationTypeKey,RecordStateKey,CreatedDate,ModifiedDate")] VentureLocation ventureLocation)
        {
            if (id != ventureLocation.VentureLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventureLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentureLocationExists(ventureLocation.VentureLocationId))
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
            ViewData["LocationKey"] = new SelectList(_context.Location, "LocationKey", "LocationDescription", ventureLocation.LocationKey);
            ViewData["LocationTypeKey"] = new SelectList(_context.LocationType, "LocationTypeKey", "LocationTypeDescription", ventureLocation.LocationTypeKey);
            ViewData["RecordStateKey"] = new SelectList(_context.RecordState, "RecordStateKey", "RecordStateName", ventureLocation.RecordStateKey);
            ViewData["VentureKey"] = new SelectList(_context.Venture, "VentureKey", "VentureDescription", ventureLocation.VentureKey);
            return View(ventureLocation);
        }

        // GET: VentureLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventureLocation = await _context.VentureLocation
                .Include(v => v.LocationKeyNavigation)
                .Include(v => v.LocationTypeKeyNavigation)
                .Include(v => v.RecordStateKeyNavigation)
                .Include(v => v.VentureKeyNavigation)
                .FirstOrDefaultAsync(m => m.VentureLocationId == id);
            if (ventureLocation == null)
            {
                return NotFound();
            }

            return View(ventureLocation);
        }

        // POST: VentureLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventureLocation = await _context.VentureLocation.FindAsync(id);
            _context.VentureLocation.Remove(ventureLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentureLocationExists(int id)
        {
            return _context.VentureLocation.Any(e => e.VentureLocationId == id);
        }
    }
}
