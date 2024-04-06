using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JournalMVC.Database;
using JournalMVC.Models;

namespace JournalMVC.Controllers
{
    public class TimeIntervalsController : Controller
    {
        private readonly ApplicationContext _context;

        public TimeIntervalsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: TimeIntervals
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeIntervals.ToListAsync());
        }

        // GET: TimeIntervals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeInterval = await _context.TimeIntervals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeInterval == null)
            {
                return NotFound();
            }

            return View(timeInterval);
        }

        // GET: TimeIntervals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeIntervals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartActivity,EndActivity")] TimeInterval timeInterval)
        {
            _context.Add(timeInterval);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TimeIntervals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeInterval = await _context.TimeIntervals.FindAsync(id);
            if (timeInterval == null)
            {
                return NotFound();
            }
            return View(timeInterval);
        }

        // POST: TimeIntervals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartActivity,EndActivity")] TimeInterval timeInterval)
        {
            if (id != timeInterval.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeInterval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeIntervalExists(timeInterval.Id))
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
            return View(timeInterval);
        }

        // GET: TimeIntervals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeInterval = await _context.TimeIntervals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeInterval == null)
            {
                return NotFound();
            }

            return View(timeInterval);
        }

        // POST: TimeIntervals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeInterval = await _context.TimeIntervals.FindAsync(id);
            if (timeInterval != null)
            {
                _context.TimeIntervals.Remove(timeInterval);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeIntervalExists(int id)
        {
            return _context.TimeIntervals.Any(e => e.Id == id);
        }
    }
}
