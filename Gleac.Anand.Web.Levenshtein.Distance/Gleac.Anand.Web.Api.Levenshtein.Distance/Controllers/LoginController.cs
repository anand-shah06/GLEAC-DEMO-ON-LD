using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
//using Gleac.Anand.Web.Api.Levenshtein.Distance.Models;
using Gleac.Anand.Levenshtein.Distance;
using System.Security.Claims;

namespace Gleac.Anand.Web.Api.Levenshtein.Distance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Login([FromBody]UserModel login)
        //{
        //    IActionResult response = Unauthorized();
        //    var user = AuthenticateUser(login);

        //    if (user != null)
        //    {
        //        var tokenString = GenerateJSONWebToken(user);
        //        response = Ok(new { token = tokenString });
        //    }

        //    return response;
        //}


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserModel login)
        {
            //const string accessTokenSession = "Access_Token";
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);                
                response = Ok(new StringToken { JWTToken = tokenString });
            }
            else
            {
                response = BadRequest("Could not login. Mail to anand_shah06@outlook.com");
            }
            return response;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            var currentUser = HttpContext.User;
            int spendingTimeWithCompany = 0;

            if (currentUser.HasClaim(c => c.Type == "DateOfJoining"))
            {
                DateTime date = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "DateOfJoing").Value);
                spendingTimeWithCompany = DateTime.Today.Year - date.Year;
            }

            if (spendingTimeWithCompany > 5)
            {
                return new string[] { "High Time1", "High Time2", "High Time3", "High Time4", "High Time5" };
            }
            else
            {
                return new string[] { "value1", "value2", "value3", "value4", "value5" };
            }
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
            new Claim("DateOfJoing", userInfo.DateOfJoining.ToString("yyyy-MM-dd")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.Username.ToUpper() == "Anand".ToUpper())
            {
                user = new UserModel { Username = "Anand Shah", EmailAddress = "anand_shah06@outlook.com" };
            }
            return user;
        }
    }
}