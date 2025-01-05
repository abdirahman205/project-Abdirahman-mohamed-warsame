using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_asp.net.Models;
using project_asp.net.data;

namespace project_asp.net.Controllers
{
    public class ParkingHistoriesController : Controller
    {
        private readonly webDbcontext _context;

        public ParkingHistoriesController(webDbcontext context)
        {
            _context = context;
        }

        // GET: ParkingHistories
        public async Task<IActionResult> Index()
        {
            var webDbcontext = _context.ParkingHistory.Include(p => p.Reservations);
            return View(await webDbcontext.ToListAsync());
        }

        // GET: ParkingHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingHistory = await _context.ParkingHistory
                .Include(p => p.Reservations)
                .FirstOrDefaultAsync(m => m.history_id == id);
            if (parkingHistory == null)
            {
                return NotFound();
            }

            return View(parkingHistory);
        }

        // GET: ParkingHistories/Create
        public IActionResult Create()
        {
            ViewData["reservation_id"] = new SelectList(_context.Reservations, "reservation_id", "reservation_id");
            return View();
        }

        // POST: ParkingHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("history_id,spot_id,reservation_id,entry_time,exit_time")] ParkingHistory parkingHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["reservation_id"] = new SelectList(_context.Reservations, "reservation_id", "reservation_id", parkingHistory.reservation_id);
            return View(parkingHistory);
        }

        // GET: ParkingHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingHistory = await _context.ParkingHistory.FindAsync(id);
            if (parkingHistory == null)
            {
                return NotFound();
            }
            ViewData["reservation_id"] = new SelectList(_context.Reservations, "reservation_id", "reservation_id", parkingHistory.reservation_id);
            return View(parkingHistory);
        }

        // POST: ParkingHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("history_id,spot_id,reservation_id,entry_time,exit_time")] ParkingHistory parkingHistory)
        {
            if (id != parkingHistory.history_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingHistoryExists(parkingHistory.history_id))
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
            ViewData["reservation_id"] = new SelectList(_context.Reservations, "reservation_id", "reservation_id", parkingHistory.reservation_id);
            return View(parkingHistory);
        }

        // GET: ParkingHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingHistory = await _context.ParkingHistory
                .Include(p => p.Reservations)
                .FirstOrDefaultAsync(m => m.history_id == id);
            if (parkingHistory == null)
            {
                return NotFound();
            }

            return View(parkingHistory);
        }

        // POST: ParkingHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingHistory = await _context.ParkingHistory.FindAsync(id);
            if (parkingHistory != null)
            {
                _context.ParkingHistory.Remove(parkingHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingHistoryExists(int id)
        {
            return _context.ParkingHistory.Any(e => e.history_id == id);
        }
    }
}
