using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Brands.Core.Services.Interfaces;
using Brands.DataLayer.Entities;
using Brands.Core.Generator;
using Newtonsoft.Json;
using GleamTech.ImageUltimate;

namespace Brands.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandCRUDController : ControllerBase
    {

        IBrandRepository _brand;

        public BrandCRUDController(IBrandRepository brand)
        {
            _brand = brand;  //Dependency Injection for repository.
        }


        [HttpGet("GetAllBrandsWithoutJsonFormat")]
        public async Task<List<Brands.DataLayer.Entities.Brands>> GetAllBrandsWithoutJsonFormat()
        {
            var All = await _brand.GetAll(User.Identity.Name); 
            return All;
        }


        [HttpGet]
        public async Task<string> Get()
        {
            var All = await _brand.GetAll(User.Identity.Name);            
       
            
            var jsonBrand = JsonConvert.SerializeObject(All, Formatting.None,
                       new JsonSerializerSettings()
                       {
                           ReferenceLoopHandling = ReferenceLoopHandling.Ignore // This statment causes to
                                                                                //avoid from "Self 
                                                                                //referencing loop detected with
                                                                                //type" error.

                       });

            return (jsonBrand);
        }
        
        [HttpGet("GetPic/{id}")]
        public async Task<IActionResult> GetPic(int id)
        {

            string MyImageName = await _brand.GetImagesNameByBrandId(id , User.Identity.Name);//We send user name as a parameter
                                                                                              //to repository , because users should not
                                                                                              //enable to access to information of each other.

            if (MyImageName != null)
            {

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Brands Images", MyImageName);

                byte[] myBytes = System.IO.File.ReadAllBytes(imagePath);

                return Ok(myBytes);
            }
            else return Ok(null);

        }
        
        [HttpPut("EditBrand")]
        public async Task<IActionResult> Put()
        {
            var data = await HttpContext.Request.ReadFormAsync();
            var dic = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            Brands.DataLayer.Entities.Brands brand = new Brands.DataLayer.Entities.Brands();

            foreach (var kvp in data.Keys)
            {
                PropertyInfo pi =
                    brand.GetType()
                        .GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
                if (pi != null)
                {


                    if (kvp == "BrandId")
                    {
                        var t = dic[kvp];
                        pi.SetValue(brand, Convert.ToInt32(dic[kvp]), null);

                    }                  
                    else if (kvp == "PersianBrandName" || kvp == "EnglishBrandName")
                    {
                        pi.SetValue(brand, dic[kvp], null);
                    }
                  
                }
            }
            
            string oldcustomerImageName = await _brand.GetImagesNameByBrandId(brand.BrandId , User.Identity.Name);

            //We send user name as a parameter
            //to repository , because users should not
            //enable to access to information of each other.

            if (data.Files.Count > 0) //This line is meaning if user had selected any picture
                                      //by uploader.
            {

                IFormFile img = data.Files[0];
                var extension = Path.GetExtension(img.FileName);
                brand.BrandPicture = GenerateUniqCode.GenerateTheUniqCode() + "." + extension;
                string savePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/Brands Images", brand.BrandPicture);
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
                try
                {
                    using (var imageTask = new ImageTask(savePath))
                        imageTask.ResizeWidth(150).Save(savePath);
                }
                catch
                {
                    System.IO.File.Delete(savePath);
                    return NotFound();  //If picture was not in correct format , this catch will run and
                                        //first will delete saved picture , then the code returns 404 error,
                                        //we could use another error numbers and this number is used Contractual
                                        //and it will be understandable for our javascript code in view.
                }

                if (oldcustomerImageName != null)   //In this block old image will be deleted.
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(),
                       "wwwroot/Brands Images", oldcustomerImageName);
                    if (System.IO.File.Exists(deletePath))

                    {
                        System.IO.File.Delete(deletePath);

                    }
                }
            }
            else
            {
                brand.BrandPicture = oldcustomerImageName;
            }
            

            await _brand.Update(brand , User.Identity.Name);//We send user name as a parameter
                                                            //to repository , because users should not
                                                            //enable to modify information of each other.

            return Ok(brand);
        }
        
        [HttpPost("AddBrand")]
        public async Task<IActionResult> Post()
        {
            var data = await HttpContext.Request.ReadFormAsync();
            var dic = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            Brands.DataLayer.Entities.Brands brand = new Brands.DataLayer.Entities.Brands();

            foreach (var kvp in data.Keys)
            {
                PropertyInfo pi =
                    brand.GetType()
                        .GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
                if (pi != null)
                {


                    //if (kvp == "BrandId")
                    //{
                    //    var t = dic[kvp];
                    //    pi.SetValue(brand, Convert.ToInt32(dic[kvp]), null);

                    //}
                    /*else*/
                   if (kvp == "PersianBrandName" || kvp == "EnglishBrandName")
                    {
                        pi.SetValue(brand, dic[kvp], null);
                    }               
                }
            }
            
            if (data.Files.Count > 0)   //This line is meaning if user had selected any picture
                                        //by uploader.
            {

                IFormFile img = data.Files[0];
                var extension = Path.GetExtension(img.FileName);
                brand.BrandPicture = GenerateUniqCode.GenerateTheUniqCode() + "." + extension;
                string savePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/Brands Images", brand.BrandPicture);
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
                try
                {
                    using (var imageTask = new ImageTask(savePath))
                        imageTask.ResizeWidth(150).Save(savePath);
                }
                catch
                {
                    System.IO.File.Delete(savePath);
                    return NotFound();  //If picture was not in correct format , this catch will run and
                                        //first will delete saved picture , then the code returns 404 error,
                                        //we could use another error numbers and this number is used Contractual
                                        //and it will be understandable for our javascript code in view.
                }
            }
           
            var user = User.Identity.Name;            
            await _brand.Add(brand , user);//We send user name as a parameter
                                           //to repository , because users should not
                                           //enable to Add any item to information of each other.
                                           
            
            var jsonBrand = JsonConvert.SerializeObject(brand, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore  // This statment causes to
                                                                                  //avoid from "Self 
                                                                                  //referencing loop detected with
                                                                                  //type" error.
                        });

            return Ok(jsonBrand);



        }
        
        [HttpDelete("DeleteBrand")]
        public async Task<IActionResult> Delete()
        {
            var data = await HttpContext.Request.ReadFormAsync();
            var dic = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            ///Brand brand = new Brand();
            int BrandId = 0;

            foreach (var kvp in data.Keys)
            {
          
                if (kvp == "brandId")
                {
                    BrandId = Convert.ToInt32(dic[kvp]);

                }
                
            }
            
            string oldcustomerImageName = await _brand.GetImagesNameByBrandId(BrandId , User.Identity.Name);
            //We send user name as a parameter
            //to repository , because users should not
            //enable to access to information of each other.
            
            if (oldcustomerImageName != null)
            {
                string deletePath = Path.Combine(Directory.GetCurrentDirectory(),
                   "wwwroot/Brands Images", oldcustomerImageName);
                if (System.IO.File.Exists(deletePath))

                {
                    System.IO.File.Delete(deletePath);

                }
            }
            
            var user = User.Identity.Name;
            await _brand.DeleteById(BrandId , user);//We send user name as a parameter
                                                    //to repository , because users should not
                                                    //enable to delete information of each other.

            return Ok(true);
            
        }
        
    }
}
