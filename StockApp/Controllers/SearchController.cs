using Microsoft.AspNetCore.Mvc;

namespace StockApp.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
