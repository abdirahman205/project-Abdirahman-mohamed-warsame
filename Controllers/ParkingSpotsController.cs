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
    public class ParkingSpotsController : Controller
    {
        private readonly webDbcontext _context;

        public ParkingSpotsController(webDbcontext context)
        {
            _context = context;
        }

        // GET: ParkingSpots
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkingSpots.ToListAsync());
        }

        // GET: ParkingSpots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpots = await _context.ParkingSpots
                .FirstOrDefaultAsync(m => m.spot_id == id);
            if (parkingSpots == null)
            {
                return NotFound();
            }

            return View(parkingSpots);
        }

        // GET: ParkingSpots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingSpots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("spot_id,location,price_per_hour")] ParkingSpots parkingSpots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingSpots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingSpots);
        }

        // GET: ParkingSpots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpots = await _context.ParkingSpots.FindAsync(id);
            if (parkingSpots == null)
            {
                return NotFound();
            }
            return View(parkingSpots);
        }

        // POST: ParkingSpots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("spot_id,location,price_per_hour")] ParkingSpots parkingSpots)
        {
            if (id != parkingSpots.spot_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingSpots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingSpotsExists(parkingSpots.spot_id))
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
            return View(parkingSpots);
        }

        // GET: ParkingSpots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpots = await _context.ParkingSpots
                .FirstOrDefaultAsync(m => m.spot_id == id);
            if (parkingSpots == null)
            {
                return NotFound();
            }

            return View(parkingSpots);
        }

        // POST: ParkingSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingSpots = await _context.ParkingSpots.FindAsync(id);
            if (parkingSpots != null)
            {
                _context.ParkingSpots.Remove(parkingSpots);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingSpotsExists(int id)
        {
            return _context.ParkingSpots.Any(e => e.spot_id == id);
        }
    }
}
