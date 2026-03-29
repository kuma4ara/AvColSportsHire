using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvColSportsHire.Areas.Identity.Data;
using AvColSportsHire.Models;

namespace AvColSportsHire.Controllers
{
    public class FacilitiesController : Controller
    {
        private readonly SportsHireContext _context;

        public FacilitiesController(SportsHireContext context)
        {
            _context = context;
        }

        // GET: Facilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facilities.ToListAsync());
        }

        // GET: Facilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilities = await _context.Facilities
                .FirstOrDefaultAsync(m => m.FacilityId == id);
            if (facilities == null)
            {
                return NotFound();
            }

            return View(facilities);
        }

        // GET: Facilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacilityId,Name,Type,Description,HourlyRate")] Facilities facilities)
        {
            try
            {
                    if (ModelState.IsValid)
                {
                    _context.Add(facilities);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(facilities);
        }

        // GET: Facilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilities = await _context.Facilities.FindAsync(id);
            if (facilities == null)
            {
                return NotFound();
            }
            return View(facilities);
        }

        // POST: Facilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacilityId,Name,Type,Description,HourlyRate")] Facilities facilities)
        {
            if (id != facilities.FacilityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilitiesExists(facilities.FacilityId))
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
            return View(facilities);
        }

        // GET: Facilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilities = await _context.Facilities
                .FirstOrDefaultAsync(m => m.FacilityId == id);
            if (facilities == null)
            {
                return NotFound();
            }

            return View(facilities);
        }

        // POST: Facilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facilities = await _context.Facilities.FindAsync(id);
            if (facilities != null)
            {
                _context.Facilities.Remove(facilities);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilitiesExists(int id)
        {
            return _context.Facilities.Any(e => e.FacilityId == id);
        }
    }
}
