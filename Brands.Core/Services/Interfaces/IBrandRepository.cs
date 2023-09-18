using Brands.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Brands.Core.Services.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<Brands.DataLayer.Entities.Brands>> GetAll(string user);

        Task<Brands.DataLayer.Entities.Brands> GetById(int brandId);

        Task<Brands.DataLayer.Entities.Brands> Add(Brands.DataLayer.Entities.Brands brand , string user);

        Task<int> DeleteById(int BrandId , string user);

        Task<int> Delete(Brands.DataLayer.Entities.Brands brand);

        Task<int> Update(Brands.DataLayer.Entities.Brands NewBrand , string user);

        Task<string> GetImagesNameByBrandId(int brandId , string user);
        
    }
}
