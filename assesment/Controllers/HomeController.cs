﻿using assesment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace assesment.Controllers
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
            //var client = new RestClient("https://api.currencyapi.com");
            //var request = new RestRequest() {
            //     Method = Method.Get,
            //     Resource= "/v3/latest?apikey=IG5u9PqkFLugbHgRXo79eoGt4WUT8vcJ7RECLa8b&currencies=EUR%2CUSD%2CCAD"
            //};
            //var response = client.ExecuteGetAsync(request).Result;

            //var content = response.Content;
            //return Json(content);
        }


        [HttpPost]

        public IActionResult FreeCurrency()
        {
            var client = new RestClient("https://api.currencyapi.com");
            var request = new RestRequest()
            {
                Method = Method.Get,
                Resource = "/v3/latest?apikey=IG5u9PqkFLugbHgRXo79eoGt4WUT8vcJ7RECLa8b&currencies=EUR%2CUSD%2CCAD"
            };
            var response = client.ExecuteGetAsync(request).Result;

            var content = response.Content;
            return Json(content);
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
