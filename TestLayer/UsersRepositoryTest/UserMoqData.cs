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

            var mockSetUser = CreateDbSetMocks.CreateDbSetMock(users.AsQueryable());//This line causes to 
                                                                                    //create a mock DbSet.(DbSet is an object that
                                                                                    //causes we access to database in Entity Framework)

            //The below block is mocking FindAsync method of a DbSet object.
            mockSetUser.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync((object[] r) =>
            {
                var id = (int)r[0];
                return users.FirstOrDefault(x => x.UserId == id);                
            });

            //The below block is mocking GetEnumerator method of a DbSet object.
            mockSetUser.As<IAsyncEnumerable<User>>()  //Finally it will returns an Enumerator type.
               .Setup(m => m.GetEnumerator())
               .Returns(new TestAsyncEnumerator<User>(users.GetEnumerator()));  //The TestAsyncEnumerator class is a mock of IAsyncEnumerator.

            //The below block is mocking Query Provider class. mocked Provider will be TestAsyncQueryProvider<User> class.
            //Using mocked Query Provider causes program can send varios values to query output.
            //One of the query provider task is convert LINQ statements to SQL.
            mockSetUser.As<IQueryable<User>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<User>(users.Provider));

            mockSetUser.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            var contextOptions = new DbContextOptions<BrandsContext>();
            var mockContext = new Mock<BrandsContext>(contextOptions);  //mockContext is the mocked of BrandsContext class (and it is created 
                                                                        //by contextOptions class.

            mockContext.Setup(c => c.Users).Returns(mockSetUser.Object);  //This line is mocking Users to mockSetUser.Object .

            var entityRepository = new UserRepository(mockContext.Object);

            return entityRepository;
        }
    }
}
