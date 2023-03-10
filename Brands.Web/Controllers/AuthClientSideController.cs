using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Brands.Core.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Brands.Web.Controllers
{
    public class AuthClientSideController : Controller
    {

        private IHttpClientFactory _httpClientFactory;

        public AuthClientSideController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("/Login")]
        public IActionResult Login()
        {
            //LoginViewModel log = new LoginViewModel();
            //log.MobileNumber = "123";

            return View(/*log*/);
        }



        [Route("/Login")]
        [HttpPost]

        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var _client = _httpClientFactory.CreateClient("Beh");
            var jsonBody = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = _client.PostAsync("/Api/AuthServerSide", content).Result;//This line causes to sent loginViewModel 
                                                                                    //to AuthServerSide Controller.
            if (response.IsSuccessStatusCode)       //If AuthServerSide Controller was executed successfully ,
                                                    //then this condition will returns true.
            {
                var token = response.Content.ReadAsAsync<TokenModel>().Result;
                var claims = new List<Claim>()
                {                    

                    new Claim(ClaimTypes.NameIdentifier,login.UserName),
                    new Claim(ClaimTypes.Name,login.UserName),                    
                    new Claim("AccessToken",token.Token)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = login.RememberMe,
                    AllowRefresh = true
                };
                HttpContext.SignInAsync(principal, properties); //This line causes to Signing in user in AuthClientSide
                                                                //controller.
                return Redirect("/BrandCRUDclient");
            }
            else
            {
                ModelState.AddModelError("Username", "User Is Existed In Database But Password Is Not Correct!");
                return View(login);
            }
        }

        
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //The above line causes to signing out the user in AuthClientSide controller.
            return Redirect("/Login");
        }

        


    }
}