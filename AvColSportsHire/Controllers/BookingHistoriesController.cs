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
    public class BookingHistoriesController : Controller
    {
        private readonly SportsHireContext _context;

        public BookingHistoriesController(SportsHireContext context)
        {
            _context = context;
        }

        // GET: BookingHistories
        public async Task<IActionResult> Index()
        {
            var sportsHireContext = _context.BookingHistory.Include(b => b.Booking);
            return View(await sportsHireContext.ToListAsync());
        }

        // GET: BookingHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingHistory = await _context.BookingHistory
                .Include(b => b.Booking)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (bookingHistory == null)
            {
                return NotFound();
            }

            return View(bookingHistory);
        }

        // GET: BookingHistories/Create
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingReference");
            return View();
        }

        // POST: BookingHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoryId,BookingId,OldStartDateTime,OldEndDateTime,ChangedByStaffId,Reason,ChangedAt")] BookingHistory bookingHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingReference", bookingHistory.BookingId);
            return View(bookingHistory);
        }

        // GET: BookingHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingHistory = await _context.BookingHistory.FindAsync(id);
            if (bookingHistory == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingReference", bookingHistory.BookingId);
            return View(bookingHistory);
        }

        // POST: BookingHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoryId,BookingId,OldStartDateTime,OldEndDateTime,ChangedByStaffId,Reason,ChangedAt")] BookingHistory bookingHistory)
        {
            if (id != bookingHistory.HistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingHistoryExists(bookingHistory.HistoryId))
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
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingReference", bookingHistory.BookingId);
            return View(bookingHistory);
        }

        // GET: BookingHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingHistory = await _context.BookingHistory
                .Include(b => b.Booking)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (bookingHistory == null)
            {
                return NotFound();
            }

            return View(bookingHistory);
        }

        // POST: BookingHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingHistory = await _context.BookingHistory.FindAsync(id);
            if (bookingHistory != null)
            {
                _context.BookingHistory.Remove(bookingHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingHistoryExists(int id)
        {
            return _context.BookingHistory.Any(e => e.HistoryId == id);
        }
    }
}
