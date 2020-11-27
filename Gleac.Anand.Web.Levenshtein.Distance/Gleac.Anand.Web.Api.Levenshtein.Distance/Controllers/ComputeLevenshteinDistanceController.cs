using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Gleac.Anand.Levenshtein.Distance;

namespace Gleac.Anand.Web.Api.Levenshtein.Distance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputeLevenshteinDistanceController : ControllerBase
    {
        private IConfiguration _config;

        public ComputeLevenshteinDistanceController(IConfiguration config)
        {
            _config = config;
        }

        //[AllowAnonymous]
        //[Authorize]
        //[HttpPost]
        //public IActionResult ComputeLevenshteinDistance(StringsModel stringsModel)
        //{            
        //    int n = stringsModel.FirstString.Length;
        //    int m = stringsModel.SecondString.Length;
        //    IActionResult response = Unauthorized();
        //    int[,] arrCompute = StringDistance.GetLevenshteinDistanceMatrix(stringsModel.FirstString, stringsModel.SecondString);
        //    response = Ok(new { arrCompute = arrCompute });
        //    return response;
        //}

        //[AllowAnonymous]
        [Authorize]
        [HttpPost]
        public IActionResult ComputeLevenshteinDistance(StringsModel stringsModel)
        {
            if (stringsModel == null)
                return BadRequest("Invalid argument(s).");
            //
            if(string.IsNullOrEmpty(stringsModel.FirstString) || string.IsNullOrEmpty(stringsModel.SecondString))
                return BadRequest("Invalid argument(s).");
            //
            int n = stringsModel.FirstString.Length;
            int m = stringsModel.SecondString.Length;
            IActionResult response = Unauthorized();
            LevenshteinDistanceMatrixAndCostResult levenshteinDistanceMatrixAndCostResult = StringDistance.GetLevenshteinDistanceMatrixAndCost(stringsModel.FirstString, stringsModel.SecondString);
            response = Ok(levenshteinDistanceMatrixAndCostResult);
            return response;
        }
    }
}