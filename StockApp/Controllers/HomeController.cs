using Microsoft.AspNetCore.Mvc;
using StockApp.Data.ApiLogic;
using StockApp.Models;
using StockApp.Models.DisplayPageModels;
using System.Diagnostics;

namespace StockApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult SearchStock()
        {
            return View();
        }

        public IActionResult DisplayStock(string stock)
        {
            var stockOverviewDisplayApi = new StockOverviewDisplayApi();
            DisplayMasterModel myModel = new DisplayMasterModel();

            myModel.QuoteModel = stockOverviewDisplayApi.GetQuote(stock);
            myModel.StockOverviewModel = stockOverviewDisplayApi.GetStockOverviewDisplay(stock);
           

            return View(myModel);
        }

        public IActionResult News(string stock)
        {
            var newsApi = new NewsApi();
            var newsModel = newsApi.GetStockNews(stock);


            return View(newsModel);
        }

        public IActionResult TipNTutorials()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetSuggestions(string term)
        {
            // Search your database or other data source for suggestions that match the user's input
            var suggestions = new List<KeyValuePair<string, string>>();
            suggestions.Add(new KeyValuePair<string, string>("Tesla", "TSLA"));
            suggestions.Add(new KeyValuePair<string, string>("IBM", "IBM"));
            suggestions.Add(new KeyValuePair<string, string>("Apple", "AAPL"));
            // Return the list of suggestions as a JSON object
            return Json(suggestions);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}