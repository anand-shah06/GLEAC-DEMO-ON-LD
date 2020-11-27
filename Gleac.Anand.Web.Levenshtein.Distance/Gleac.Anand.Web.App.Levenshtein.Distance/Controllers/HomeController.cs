using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gleac.Anand.Web.App.Levenshtein.Distance.Models;
using Gleac.Anand.Web.App.Levenshtein.Distance.Client;
using Gleac.Anand.Levenshtein.Distance;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Gleac.Anand.Web.App.Levenshtein.Distance.Controllers
{
    public class HomeController : Controller
    {
        const string accessTokenSession = "Access_Token";
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration configuration) {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            LevenshteinDistanceViewModel levenshteinDistanceViewModel = new LevenshteinDistanceViewModel();
            return View(levenshteinDistanceViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetJwtToken()
        {
            StringToken JWTTokenDone = null;            
            //
            LevenshteinDistanceViewModel levenshteinDistanceViewModel = new LevenshteinDistanceViewModel();
            UserModel userModel = new UserModel { Username = "Anand", Password = "********", EmailAddress = "anand_shah06@outlook.com" };
            //
            using (LevenshteinDistanceApiClient levenshteinDistanceApiClient = new LevenshteinDistanceApiClient(this.configuration))
            {
                JWTTokenDone = await levenshteinDistanceApiClient.SetJwtToken(userModel);
                if (JWTTokenDone != null)
                {
                    HttpContext.Session.SetString(accessTokenSession,  JWTTokenDone.JWTToken);
                    ViewData["JWTToken"] = HttpContext.Session.GetString(accessTokenSession);
                }
            }
            return View("Index", levenshteinDistanceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetLevenshteinDistanceResult(StringsViewModel stringsViewModel)
        {
            LevenshteinDistanceViewModel levenshteinDistanceViewModel = null;
            LevenshteinDistanceMatrixAndCostResult levenshteinDistanceMatrixAndCostResult = null;
            StringsModel stringsModel = null;
            string JWTToken = null;
            
            if (stringsViewModel != null)
            {
                stringsModel = new StringsModel { FirstString = stringsViewModel.FirstString
                                                  , SecondString = stringsViewModel.SecondString };
                JWTToken = HttpContext.Session.GetString(accessTokenSession).ToString();
                ViewData["JWTToken"] = HttpContext.Session.GetString(accessTokenSession);
                using (LevenshteinDistanceApiClient levenshteinDistanceApiClient = new LevenshteinDistanceApiClient(this.configuration))
                {
                    levenshteinDistanceMatrixAndCostResult = await levenshteinDistanceApiClient.GetLevenshteinDistanceMatrixAndCostResult(stringsModel, JWTToken);
                }
                if(levenshteinDistanceMatrixAndCostResult != null)
                {
                    levenshteinDistanceViewModel = new LevenshteinDistanceViewModel
                    {                       
                        StringsAsCriteria = new StringsViewModel
                        {
                            FirstString = levenshteinDistanceMatrixAndCostResult.StringsAsCriteria.FirstString
                            , SecondString = levenshteinDistanceMatrixAndCostResult.StringsAsCriteria.SecondString
                        },
                        ResultTable = new LevenshteinResultTableViewModel { Cost = levenshteinDistanceMatrixAndCostResult.Cost
                                                                            , ResultMatrix = levenshteinDistanceMatrixAndCostResult.MatrixResult
                                                                          }
                    };
                }
            }
            return View("Index", levenshteinDistanceViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page.";

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
