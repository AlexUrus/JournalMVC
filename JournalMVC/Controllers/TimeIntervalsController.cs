using JournalMVC.DTO;
using JournalMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JournalMVC.Controllers
{
    public class TimeIntervalsController : Controller
    {
        private readonly ITimeIntervalsService _timeIntervalsService;

        public TimeIntervalsController(ITimeIntervalsService timeIntervalsService)
        {
            _timeIntervalsService = timeIntervalsService;
        }

        // GET: TimeIntervals
        public async Task<IActionResult> Index()
        {
            var timeIntervals = await _timeIntervalsService.GetAsync();
            ViewData["TimeIntervals"] = new SelectList(timeIntervals, "Id", "Interval");
            return View(timeIntervals);
        }

        // GET: TimeIntervals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeInterval = await _timeIntervalsService.GetAsync((int)id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartActivity,EndActivity")] TimeIntervalDTO timeIntervalDTO)
        {
            await _timeIntervalsService.AddAsync(timeIntervalDTO);
            return RedirectToAction(nameof(Index));
        }

        // GET: TimeIntervals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeIntervalDTO = await _timeIntervalsService.GetAsync((int)id);
            if (timeIntervalDTO == null)
            {
                return NotFound();
            }
            return View(timeIntervalDTO);
        }

        // POST: TimeIntervals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartActivity,EndActivity")] TimeIntervalDTO timeIntervalDto)
        {
            if (id != timeIntervalDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _timeIntervalsService.UpdateAsync(timeIntervalDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TimeIntervalExists(timeIntervalDto.Id))
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
            return View(timeIntervalDto);
        }

        // GET: TimeIntervals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeInterval = await _timeIntervalsService.GetAsync((int)id);
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
            await _timeIntervalsService.DeleteAsync(new TimeIntervalDTO { Id = id });
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TimeIntervalExists(int id)
        {
            return await _timeIntervalsService.GetAsync(id) != null;
        }
    }
}
