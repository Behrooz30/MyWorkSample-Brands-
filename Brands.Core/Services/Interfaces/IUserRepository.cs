using Brands.Core.DTOs;
using Brands.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brands.Core.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<int> LoginOrRegisterUser(LoginViewModel login);
        Task<int> RegisterUser(LoginViewModel user);
        Task<int> GetUserIdByUserName(string userName);
       
    }
}
