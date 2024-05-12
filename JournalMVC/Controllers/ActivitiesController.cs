using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JournalMVC.Database;
using JournalMVC.Models;
using JournalMVC.Services.Interfaces;
using JournalMVC.DTO;
using JournalMVC.Services;

namespace JournalMVC.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IActivitiesService _activityService;
        private readonly ITypeActivitiesService _typeActivitiesService;
        private readonly ITimeIntervalsService _timeIntervalsService;

        public ActivitiesController(IActivitiesService activityService,
            ITimeIntervalsService timeIntervalsService, ITypeActivitiesService typeActivitiesService)
        {
            (_activityService, _typeActivitiesService, _timeIntervalsService) = (activityService, typeActivitiesService, timeIntervalsService);
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            var activities = await _activityService.GetAsync();
            return View(activities);
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _activityService.GetAsync((int)id);

            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public async Task<IActionResult> Create()
        {
            ViewData["TimeIntervals"] = new SelectList(await _timeIntervalsService.GetAsync(), "Id", "Interval");
            ViewData["TypeActivities"] = new SelectList(await _typeActivitiesService.GetAsync(), "Id", "Name");
            return View();
        }

        // POST: Activities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeId,TimeIntervalId,Description")] ActivityDTO activityDto)
        {
            await _activityService.AddAsync(activityDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityDto = await _activityService.GetAsync((int)id);
            if (activityDto == null)
            {
                return NotFound();
            }
            ViewData["TimeIntervals"] = new SelectList(await _timeIntervalsService.GetAsync(), "Id", "Interval", activityDto.TimeIntervalId);
            ViewData["TypeActivities"] = new SelectList(await _typeActivitiesService.GetAsync(), "Id", "Name", activityDto.TypeId);
            return View(activityDto);
        }

        // POST: Activities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,TimeIntervalId,Description")] ActivityDTO activityDto)
        {
            if (id != activityDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _activityService.UpdateAsync(activityDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ActivityExists(activityDto.Id))
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
            ViewData["TimeIntervals"] = new SelectList(await _timeIntervalsService.GetAsync(), "Id", "Interval", activityDto.TimeIntervalId);
            ViewData["TypeActivities"] = new SelectList(await _typeActivitiesService.GetAsync(), "Id", "Name", activityDto.TypeId);
            return View(activityDto);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _activityService.GetAsync((int)id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _activityService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ActivityExists(int id)
        {
            return await _activityService.GetAsync(id) != null;
        }
    }
}
