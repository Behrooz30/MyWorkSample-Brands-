using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Brands.Core.DomainName;
using Brands.Core.DTOs;
using Brands.Core.Services.Interfaces;
using Brands.DataLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Brands.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthServerSideController : ControllerBase
    {
        IUserRepository _user;
        public AuthServerSideController(IUserRepository user)
        {
            _user = user;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The Model Is Not Valid");
            }

            //if (login.UserName.ToLower() != "George" || login.Password.ToLower() != "123")
            //{
            //    return Unauthorized();
            //}

            var newUserId =  _user.LoginOrRegisterUser(login).Result;
            if (newUserId == -1)
                return Unauthorized();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurVerifyTopLearn"));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOption = new JwtSecurityToken(
                issuer: MyDomain.Domain,
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name,login.UserName),
                    new Claim(ClaimTypes.Role,"Admin")
                },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
            
            return Ok(new { token = tokenString });
            
        }
    }
}