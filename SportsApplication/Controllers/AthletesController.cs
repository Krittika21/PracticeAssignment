using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsApplication.Models;

namespace SportsApplication.Controllers
{
    public class AthletesController : Controller
    {
        private readonly SportsApplicationContext _context;

        public AthletesController(SportsApplicationContext context)
        {
            _context = context;
        }

        // GET: Athletes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Athletes.ToListAsync());
        }

        // GET: Athletes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athletes = await _context.Athletes
                .FirstOrDefaultAsync(m => m.AthletesID == id);
            if (athletes == null)
            {
                return NotFound();
            }

            return View(athletes);
        }

        // GET: Athletes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AthletesID,ParticipantName,Distance,Fitness")] Athletes athletes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(athletes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(athletes);
        }

        // GET: Athletes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athletes = await _context.Athletes.FindAsync(id);
            if (athletes == null)
            {
                return NotFound();
            }
            return View(athletes);
        }

        // POST: Athletes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AthletesID,ParticipantName,Distance,Fitness")] Athletes athletes)
        {
            if (id != athletes.AthletesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(athletes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthletesExists(athletes.AthletesID))
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
            return View(athletes);
        }

        // GET: Athletes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athletes = await _context.Athletes
                .FirstOrDefaultAsync(m => m.AthletesID == id);
            if (athletes == null)
            {
                return NotFound();
            }

            return View(athletes);
        }

        // POST: Athletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var athletes = await _context.Athletes.FindAsync(id);
            _context.Athletes.Remove(athletes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AthletesExists(int id)
        {
            return _context.Athletes.Any(e => e.AthletesID == id);
        }
    }
}
