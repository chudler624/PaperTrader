﻿using Microsoft.AspNetCore.Mvc;
using StockApp.Data.ApiLogic;
using StockApp.Models;
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