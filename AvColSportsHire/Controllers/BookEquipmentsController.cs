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
    public class BookEquipmentsController : Controller
    {
        private readonly SportsHireContext _context;

        public BookEquipmentsController(SportsHireContext context)
        {
            _context = context;
        }

        // GET: BookEquipments
        public async Task<IActionResult> Index()
        {
            var sportsHireContext = _context.BookEquipment.Include(b => b.Booking).Include(b => b.Equipment);
            return View(await sportsHireContext.ToListAsync());
        }

        // GET: BookEquipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookEquipment = await _context.BookEquipment
                .Include(b => b.Booking)
                .Include(b => b.Equipment)
                .FirstOrDefaultAsync(m => m.BookEquipId == id);
            if (bookEquipment == null)
            {
                return NotFound();
            }

            return View(bookEquipment);
        }

        // GET: BookEquipments/Create
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingReference");
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "Name");
            return View();
        }

        // POST: BookEquipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookEquipId,BookingId,EquipmentId,QuantityBooked")] BookEquipment bookEquipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookEquipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingReference", bookEquipment.BookingId);
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "Name", bookEquipment.EquipmentId);
            return View(bookEquipment);
        }

        // GET: BookEquipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookEquipment = await _context.BookEquipment.FindAsync(id);
            if (bookEquipment == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingReference", bookEquipment.BookingId);
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "Name", bookEquipment.EquipmentId);
            return View(bookEquipment);
        }

        // POST: BookEquipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookEquipId,BookingId,EquipmentId,QuantityBooked")] BookEquipment bookEquipment)
        {
            if (id != bookEquipment.BookEquipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookEquipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookEquipmentExists(bookEquipment.BookEquipId))
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
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingReference", bookEquipment.BookingId);
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "Name", bookEquipment.EquipmentId);
            return View(bookEquipment);
        }

        // GET: BookEquipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookEquipment = await _context.BookEquipment
                .Include(b => b.Booking)
                .Include(b => b.Equipment)
                .FirstOrDefaultAsync(m => m.BookEquipId == id);
            if (bookEquipment == null)
            {
                return NotFound();
            }

            return View(bookEquipment);
        }

        // POST: BookEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookEquipment = await _context.BookEquipment.FindAsync(id);
            if (bookEquipment != null)
            {
                _context.BookEquipment.Remove(bookEquipment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookEquipmentExists(int id)
        {
            return _context.BookEquipment.Any(e => e.BookEquipId == id);
        }
    }
}
