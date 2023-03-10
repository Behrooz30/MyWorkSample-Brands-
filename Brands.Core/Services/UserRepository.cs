using Brands.Core.Convertors;
using Brands.Core.DTOs;
using Brands.Core.Services.Interfaces;
using Brands.DataLayer.Context;
using Brands.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brands.Core.Services
{
    public class UserRepository : IUserRepository
    {
        BrandsContext _context;
        public UserRepository(BrandsContext context)
        {
            _context = context;
        }

        public async Task<int> GetUserIdByUserName(string userName)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == FixedText.FixText(userName));
            return user.UserId;
        }

        public async Task<int> LoginOrRegisterUser(LoginViewModel login)
        {
            string hashedPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            string userName = FixedText.FixText(login.UserName);
            if (!(await _context.Users.AnyAsync(u => u.UserName == userName)))  //This block run when an user
                                                                                //try to login first time.
            {
                var temp = await RegisterUser(login);
                return temp;
            }
            else                                                     //This block run when an user
                                                                    //has tried to login , after previous 
                                                                    //successfuly logins , and his password is true.
                if (await _context.Users.AnyAsync(u => u.Password == hashedPassword && u.UserName == userName))
            {
                var existedUserId = (await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName)).UserId;
                return existedUserId;
            }
            else return -1;                                          //This block run when an user
                                                                     //has tried to login , after previous 
                                                                     //successfuly logins , and his password is false.
        }

        public async Task<int> RegisterUser(LoginViewModel user)
        {
            string hashedPassword = PasswordHelper.EncodePasswordMd5(user.Password);
            var newUser = new User()
            {
                UserName = FixedText.FixText(user.UserName),
                Password = hashedPassword
            };

            var temp = await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser.UserId;
        }
    }
}
