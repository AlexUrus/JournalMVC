using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JournalMVC.Controllers
{
    public class TypeActivitiesController : Controller
    {
        private readonly ITypeActivitiesService _typeActivitiesService;

        public TypeActivitiesController(ITypeActivitiesService typeActivitiesService)
        {
            _typeActivitiesService = typeActivitiesService;
        }

        // GET: TypeActivities
        public async Task<IActionResult> Index()
        {
            var typeActivities = await _typeActivitiesService.GetAsync();
            typeActivities = typeActivities.OrderBy(t => t.Name).ToList();
            return View(typeActivities);
        }

        // GET: TypeActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeActivity = await _typeActivitiesService.GetAsync((int)id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TypeActivity typeActivity)
        {
            if (ModelState.IsValid)
            {
                await _typeActivitiesService.AddAsync(new TypeActivityDTO { Name = typeActivity.Name });
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

            var typeActivity = await _typeActivitiesService.GetAsync((int)id);
            if (typeActivity == null)
            {
                return NotFound();
            }
            return View(typeActivity);
        }

        // POST: TypeActivities/Edit/5
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
                    await _typeActivitiesService.UpdateAsync(new TypeActivityDTO { Id = typeActivity.Id, Name = typeActivity.Name });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TypeActivityExists(typeActivity.Id))
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

            var typeActivity = await _typeActivitiesService.GetAsync((int)id);
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
            await _typeActivitiesService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TypeActivityExists(int id)
        {
            return await _typeActivitiesService.GetAsync(id) != null;
        }
    }
}
