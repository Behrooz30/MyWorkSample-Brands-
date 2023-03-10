using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brands.Web.Controllers
{
    [Authorize]
    public class BrandCRUDclientController : Controller
    {
        public BrandCRUDclientController()
        {

        }

        [Route("BrandCRUDclient")]
        [HttpGet]
        public IActionResult BrandCRUDclient()
        {


            string token = User.FindFirst("AccessToken").Value;



            return View("BrandCRUD", token);

        }
    }
}