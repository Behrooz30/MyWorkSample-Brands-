using Brands.Core.Services.Interfaces;
using Brands.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brands.Core.Services
{
    public class BrandRepository:IBrandRepository
    {
        BrandsContext _context;
        IUserRepository _userRepository;
        public BrandRepository(BrandsContext context , IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<Brands.DataLayer.Entities.Brands> Add(Brands.DataLayer.Entities.Brands brand , string user)
        {
            brand.UserId = await _userRepository.GetUserIdByUserName(user);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<int> Delete(Brands.DataLayer.Entities.Brands brand)
        {
            var t = await GetById(brand.BrandId);
            t.IsDelete = true;
            await _context.SaveChangesAsync();

            return 1;

        }
        public async Task<int> DeleteById(int BrandId , string user)
        {
            var temp = await GetById(BrandId);
            var userId = await _userRepository.GetUserIdByUserName(user);
            if (temp.UserId == userId)
            {
                temp.IsDelete = true;
                await _context.SaveChangesAsync();
                return 1;
            }

            return -1;
        }
        public async Task<List<Brands.DataLayer.Entities.Brands>> GetAll(string user)
        {
            var userId = await _userRepository.GetUserIdByUserName(user);
            var t = await _context.Brands.Where(b => b.UserId == userId).ToListAsync();
            return t;
        }
        public async Task<Brands.DataLayer.Entities.Brands> GetById(int brandId)
        {
        //Thid method is used in internal repository methods and it is not
        //necessary to pass userName to it.
            var t = await _context.Brands.FindAsync(brandId);
            return t;
        }

        public async Task<string> GetImagesNameByBrandId(int brandId , string user)
        {
            var userId = await _userRepository.GetUserIdByUserName(user);
            var t = await _context.Brands.FindAsync(brandId);
            if (t.UserId == userId)
                return t.BrandPicture;
            else
                return null;
        }    

        public async Task<int> Update(Brands.DataLayer.Entities.Brands NewBrand , string user)
        {
            var userId = await _userRepository.GetUserIdByUserName(user);
            var OldBrand = await _context.Brands.FindAsync(NewBrand.BrandId);
            //  _context.Brands.Update(NewBrand);
            if (OldBrand.UserId == userId)
            {
                OldBrand.EnglishBrandName = NewBrand.EnglishBrandName;
                OldBrand.IsDelete = NewBrand.IsDelete;
                OldBrand.PersianBrandName = NewBrand.PersianBrandName;
                OldBrand.BrandPicture = NewBrand.BrandPicture;


                await _context.SaveChangesAsync();
                return 1;
            }

            return -1;
        }
    }
}
