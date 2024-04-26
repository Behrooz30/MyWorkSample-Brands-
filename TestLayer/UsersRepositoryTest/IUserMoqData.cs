using Brands.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestLayer.UsersRepositoryTest
{
    public interface IUserMoqData
    {
        Task<UserRepository> UserMoqDb();
    }
}
