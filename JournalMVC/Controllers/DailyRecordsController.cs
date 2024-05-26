using JournalMVC.DTO;
using JournalMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JournalMVC.Controllers
{
    public class DailyRecordsController : Controller
    {
        private readonly IDailyRecordService _dailyRecordService;

        public DailyRecordsController(IDailyRecordService dailyRecordService)
        {
            _dailyRecordService = dailyRecordService;
        }

        public async Task<IActionResult> Index()
        {
            var dailyRecords = await _dailyRecordService.GetAsync(); 

            return View(dailyRecords); 
        }
    }
}
