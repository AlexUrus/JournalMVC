using Microsoft.AspNetCore.Mvc;

namespace JournalMVC.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
