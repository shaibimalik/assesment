using assesment.Helper;
using assesment.Models;
using assesment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace assesment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ICurrenceyRepository _currencyRepository;
        public HomeController(ILogger<HomeController> logger,
            ICurrenceyRepository currenceyRepository)
        {
            _logger = logger;
            _currencyRepository = currenceyRepository;

        }

        public IActionResult Index()
        {
            return View();
          
        }


        [HttpPost]

        public IActionResult FreeCurrency()
        {
            

            var client = new RestClient("https://api.currencyapi.com");
            var request = new RestRequest()
            {
                Method = Method.Get,
                Resource = "/v3/latest?apikey=IG5u9PqkFLugbHgRXo79eoGt4WUT8vcJ7RECLa8b&currencies=EUR%2CUSD%2CCAD%2CPKR"
            };
            var response = client.ExecuteGetAsync(request).Result;

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JsonModel>(response.Content);


                var resp = _currencyRepository.CurrencyGetValue();





                CurrencyModel currencyModel = new CurrencyModel();


                for (int i = 0; i < resp.Data.Tables[0].Rows.Count; i++)
                {
                    try
                    {

                        currencyModel.Id = (Int32)(resp.Data.Tables[0].Rows[i]["id"]);
                        currencyModel.Amount = (double)(resp.Data.Tables[0].Rows[i]["Amount"]);
                        currencyModel.CurrencyName = (string)(resp.Data.Tables[0].Rows[i]["Currency"]);
                        currencyModel.AmountUSD = resp.Data.Tables[0].Rows[i]["AmountUSD"] is DBNull ? 0 : (double)(resp.Data.Tables[0].Rows[i]["AmountUSD"]);
                        currencyModel.AmountUserCurrency = resp.Data.Tables[0].Rows[i]["AmountUserCurrency"] is DBNull ? 0 : (double)(resp.Data.Tables[0].Rows[i]["AmountUserCurrency"]);
                        XchangeRates.ConvertRates(currencyModel, content);
                        _currencyRepository.CurrencyUpdateValue(currencyModel);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }



            }
             var content1 = response.Content;
            return Json(content1);
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
