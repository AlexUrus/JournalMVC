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
    public class TypeActivitiesController : Controller
    {
        private readonly ApplicationContext _context;

        public TypeActivitiesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: TypeActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeActivities.ToListAsync());
        }

        // GET: TypeActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeActivity = await _context.TypeActivities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeActivity == null)
            {
                return NotFound();
            }

            return View(typeActivity);
        }

        // GET: TypeActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TypeActivity typeActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeActivity);
        }

        // GET: TypeActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeActivity = await _context.TypeActivities.FindAsync(id);
            if (typeActivity == null)
            {
                return NotFound();
            }
            return View(typeActivity);
        }

        // POST: TypeActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TypeActivity typeActivity)
        {
            if (id != typeActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeActivityExists(typeActivity.Id))
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
            return View(typeActivity);
        }

        // GET: TypeActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeActivity = await _context.TypeActivities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeActivity == null)
            {
                return NotFound();
            }

            return View(typeActivity);
        }

        // POST: TypeActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeActivity = await _context.TypeActivities.FindAsync(id);
            if (typeActivity != null)
            {
                _context.TypeActivities.Remove(typeActivity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeActivityExists(int id)
        {
            return _context.TypeActivities.Any(e => e.Id == id);
        }
    }
}
