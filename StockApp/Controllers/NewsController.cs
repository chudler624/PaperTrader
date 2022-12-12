using Microsoft.AspNetCore.Mvc;
using StockApp.Data.ApiLogic;

namespace StockApp.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult News(string stock)
        {
            var newsApi = new NewsApi();
            var newsModel = newsApi.GetStockNews(stock);


            return View(newsModel);
        }
    }
}
