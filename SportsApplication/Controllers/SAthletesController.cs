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
    public class SAthletesController : Controller
    {
        private readonly SportsApplicationContext _context;

        public SAthletesController(SportsApplicationContext context)
        {
            _context = context;
        }

        // GET: SAthletes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SAthletes.ToListAsync());
        }

        // GET: SAthletes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAthletes = await _context.SAthletes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sAthletes == null)
            {
                return NotFound();
            }

            return View(sAthletes);
        }

        // GET: SAthletes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SAthletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SAthletesID,Ranking,Seconds,FitnessRating")] SAthletes sAthletes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sAthletes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sAthletes);
        }

        // GET: SAthletes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAthletes = await _context.SAthletes.FindAsync(id);
            if (sAthletes == null)
            {
                return NotFound();
            }
            return View(sAthletes);
        }

        // POST: SAthletes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SAthletesID,Ranking,Seconds,FitnessRating")] SAthletes sAthletes)
        {
            if (id != sAthletes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sAthletes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SAthletesExists(sAthletes.Id))
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
            return View(sAthletes);
        }

        // GET: SAthletes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAthletes = await _context.SAthletes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sAthletes == null)
            {
                return NotFound();
            }

            return View(sAthletes);
        }

        // POST: SAthletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sAthletes = await _context.SAthletes.FindAsync(id);
            _context.SAthletes.Remove(sAthletes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SAthletesExists(int id)
        {
            return _context.SAthletes.Any(e => e.Id == id);
        }
    }
}
