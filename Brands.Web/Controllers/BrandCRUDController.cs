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
            _brand = brand;
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
                           ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                       });

            return (jsonBrand);
        }
        

        [HttpGet("GetPic/{id}")]
        public async Task<IActionResult> GetPic(int id)
        {

            string MyImageName = await _brand.GetImagesNameByBrandId(id , User.Identity.Name);

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
            
            if (data.Files.Count > 0)
            {

                IFormFile img = data.Files[0];
                var extension = Path.GetExtension(img.FileName);
                brand.BrandPicture = GenerateUniqCode.GenerateTheUniqCode() + "." + extension;// img.FileName;
                string savePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/Brands Images", brand.BrandPicture);
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
                

                if (oldcustomerImageName != null/* && data.Files.Count > 0*/)
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

            await _brand.Update(brand , User.Identity.Name);                 
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
                    
                   if (kvp == "PersianBrandName" || kvp == "EnglishBrandName")
                    {
                        pi.SetValue(brand, dic[kvp], null);
                    }               
                }
            }
            
            if (data.Files.Count > 0)
            {

                IFormFile img = data.Files[0];
                var extension = Path.GetExtension(img.FileName);
                brand.BrandPicture = GenerateUniqCode.GenerateTheUniqCode() + "." + extension;// img.FileName;
                string savePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/Brands Images", brand.BrandPicture);
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
               
            }
           
            var user = User.Identity.Name;            
            await _brand.Add(brand , user);
            

            var jsonBrand = JsonConvert.SerializeObject(brand, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            return Ok(jsonBrand);
            
        }
        

        [HttpDelete("DeleteBrand")]
        public async Task<IActionResult> Delete()
        {
            var data = await HttpContext.Request.ReadFormAsync();
            var dic = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());            
            int BrandId = 0;

            foreach (var kvp in data.Keys)
            {                
                if (kvp == "brandId")
                {
                    BrandId = Convert.ToInt32(dic[kvp]);

                }
            }
            string oldcustomerImageName = await _brand.GetImagesNameByBrandId(BrandId , User.Identity.Name);

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
            await _brand.DeleteById(BrandId , user);            
            return Ok(true);
        }
        
    }
}
