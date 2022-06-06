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

          
            var content = JsonConvert.DeserializeObject<JsonModel>(response.Content);

         


            

           // var content = response.Content;
            return Json(content);
        }


        public class XchangeRates
        {

            public ICurrenceyRepository _currencyRepository;
            public XchangeRates(
            ICurrenceyRepository currenceyRepository)
            {
                _currencyRepository = currenceyRepository;

            }

           

            public static void ConvertRates(Double Amount, Double ExchangeRate)
            {

                var resp = _currencyRepository.CurrencyGetValue();


                Double AmountUSD = Amount*ExchangeRate;


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
                        XchangeRates.ConvertRates(currencyModel.Amount, content.data.CAD.value);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }




            }
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
