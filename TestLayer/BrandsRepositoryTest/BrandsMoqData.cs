﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brands.Core.Services;
using Brands.Core.Services.Interfaces;
using Brands.DataLayer.Context;
using Brands.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace TestLayer.BrandsRepositoryTest
{
    public class BrandsMoqData : IBrandsMoqData
    {
        public async Task<BrandRepository> BrandsMoqDb()
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

            IQueryable<Brands.DataLayer.Entities.Brands> brands = new List<Brands.DataLayer.Entities.Brands>
            {
                new Brands.DataLayer.Entities.Brands()
                {
                    BrandId = 1,
                    BrandPicture = "TestPic_1.jpg",
                    EnglishBrandName = "Toyota",
                    PersianBrandName = "تویوتا",
                    UserId = 1                   

                },new Brands.DataLayer.Entities.Brands()
                {
                    BrandId = 2,
                    BrandPicture = "TestPic_2.jpg",
                    EnglishBrandName = "BMW",
                    PersianBrandName = "بی ام دبلیو",
                    UserId = 1

                },new Brands.DataLayer.Entities.Brands()
                {
                    BrandId = 3,
                    BrandPicture = "TestPic_3.jpg",
                    EnglishBrandName = "Ford",
                    PersianBrandName = "فورد",
                    UserId = 2

                }
             }.AsQueryable();

            //Create relation between User and Brands
            foreach (User user in users)
            {
                user.Brands = brands.Where(p => p.UserId == user.UserId).ToList();
            }


            foreach (Brands.DataLayer.Entities.Brands brand in brands)
            {
                brand.Users = users.SingleOrDefault(p => p.UserId == brand.UserId);
            }

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

            var mockSetBrands = CreateDbSetMocks.CreateDbSetMock(brands.AsQueryable());
            mockSetBrands.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync((object[] r) =>
            {
                var id = (int)r[0];
                return brands.FirstOrDefault(x => x.BrandId == id);
            });

            mockSetBrands.As<IAsyncEnumerable<Brands.DataLayer.Entities.Brands>>()
               .Setup(m => m.GetEnumerator())
               .Returns(new TestAsyncEnumerator<Brands.DataLayer.Entities.Brands>(brands.GetEnumerator()));

            mockSetBrands.As<IQueryable<Brands.DataLayer.Entities.Brands>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<Brands.DataLayer.Entities.Brands>(brands.Provider));

            mockSetBrands.As<IQueryable<Brands.DataLayer.Entities.Brands>>().Setup(m => m.Expression).Returns(brands.Expression);
            mockSetBrands.As<IQueryable<Brands.DataLayer.Entities.Brands>>().Setup(m => m.ElementType).Returns(brands.ElementType);
            mockSetBrands.As<IQueryable<Brands.DataLayer.Entities.Brands>>().Setup(m => m.GetEnumerator()).Returns(() => brands.GetEnumerator());

            var contextOptions = new DbContextOptions<BrandsContext>();
            var mockContext = new Mock<BrandsContext>(contextOptions);

            mockContext.Setup(c => c.Users).Returns(mockSetUser.Object);
            mockContext.Setup(c => c.Brands).Returns(mockSetBrands.Object);

            
            var entityUserRepository = new UserRepository(mockContext.Object);
            var entityBrandsRepository = new BrandRepository(mockContext.Object , entityUserRepository);

            return entityBrandsRepository;
        }
    }
}
