using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brands.Core.Services;
using Brands.DataLayer.Context;
using Brands.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestLayer.UsersRepositoryTest
{
    public class UserMoqData : IUserMoqData
    {
        public async Task<UserRepository> UserMoqDb()
        {
            IQueryable<User> users = new List<User>
            {
                new User()
                {
                    UserId = 1,
                    UserName = "george",
                    Password = "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70"//Heshed of 123

                },new User()
                {
                    UserId = 2,
                    UserName = "bill",
                    Password = "25-0C-F8-B5-1C-77-3F-3F-8D-C8-B4-BE-86-7A-9A-02"//Hashed of 456

                }
             }.AsQueryable();

            var mockSetUser = CreateDbSetMocks.CreateDbSetMock(users.AsQueryable());
            mockSetUser.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync((object[] r) =>
            {
                var id = (int)r[0];
                return users.FirstOrDefault(x => x.UserId == id);                
            });

            mockSetUser.As<IAsyncEnumerable<User>>()
               .Setup(m => m.GetEnumerator())
               .Returns(new TestAsyncEnumerator<User>(users.GetEnumerator()));

            mockSetUser.As<IQueryable<User>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<User>(users.Provider));

            mockSetUser.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            var contextOptions = new DbContextOptions<BrandsContext>();
            var mockContext = new Mock<BrandsContext>(contextOptions);

            mockContext.Setup(c => c.Users).Returns(mockSetUser.Object);

            var entityRepository = new UserRepository(mockContext.Object);

            return entityRepository;
        }
    }
}
