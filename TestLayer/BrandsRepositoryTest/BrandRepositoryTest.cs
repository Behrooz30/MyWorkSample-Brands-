using Brands.Core.DTOs;
using Brands.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
namespace TestLayer.BrandsRepositoryTest
{
    public class BrandRepositoryTest : IClassFixture<BrandsMoqData>
    {
        private IBrandsMoqData _brandsMoqData;
        public BrandRepositoryTest(BrandsMoqData brandsMoqData)
        {
            _brandsMoqData = brandsMoqData;

        }

        [Theory]
        [InlineData(2)]

        public async void GetAll(int expectedResult)
        {
            //Arrange
            string userName = "George";

            //Act
            var temp_1 = await _brandsMoqData.BrandsMoqDb()
                .Result.GetAll(userName);

            
            //Assert
            Assert.Equal(expectedResult, temp_1.Count); 
        }

        [Theory]
        [InlineData()]

        public async void GetById()
        {
            //Arrange
            int brandId = 1;

            //Act
            var temp_1 = await _brandsMoqData.BrandsMoqDb()
                .Result.GetById(brandId);


            //Assert
            Assert.Equal(1, temp_1.BrandId);
            Assert.Equal("TestPic_1.jpg", temp_1.BrandPicture);
            Assert.Equal("Toyota", temp_1.EnglishBrandName);
            Assert.Equal("تویوتا", temp_1.PersianBrandName);
            Assert.Equal(1, temp_1.UserId);            
        }
        [Theory]
        [InlineData()]

        public async void Add()
        {
            //Arrange
            var newBrand = new Brands.DataLayer.Entities.Brands() {
                BrandId = 4,
                BrandPicture = "TestPic_1.jpg",
                EnglishBrandName = "Mazda",
                PersianBrandName = "مزدا"                              
            };

            //Act
            var temp_1 = await _brandsMoqData.BrandsMoqDb()
                .Result.Add(newBrand , "George");
            


            //Assert
            Assert.Equal(4, temp_1.BrandId);
            Assert.Equal("TestPic_1.jpg", temp_1.BrandPicture);
            Assert.Equal("Mazda", temp_1.EnglishBrandName);
            Assert.Equal("مزدا", temp_1.PersianBrandName);
            Assert.Equal(1, temp_1.UserId);           
        }

        [Theory]
        [InlineData()]

        public async void DeleteById()
        {
            //Arrange            
            string userName = "George";
            

            //Act
            var temp_1 = await _brandsMoqData.BrandsMoqDb()
                .Result.DeleteById(1 , userName);

            var temp_2 = await _brandsMoqData.BrandsMoqDb()
                .Result.DeleteById(3, userName);//This is meaning if a user want to delete a brand that the brand 
                            //is not belonged to his userName.
            //Assert
            Assert.Equal(1, temp_1);
            Assert.Equal(-1, temp_2);
        }

        [Theory]
        [InlineData()]

        public async void Delete()
        {
            //Arrange
            var brand = await _brandsMoqData.BrandsMoqDb()
                  .Result.GetById(1);

            //Act
            var temp_1 = await _brandsMoqData.BrandsMoqDb()
                .Result.Delete(brand);

          
            Assert.Equal(1, temp_1);
            
        }

        [Theory]
        [InlineData()]

        public async void Update()
        {
            //Arrange            
            string userName = "George";

            var brand = await _brandsMoqData.BrandsMoqDb()
                .Result.GetById(1);

            var brand_2 = await _brandsMoqData.BrandsMoqDb()
         .Result.GetById(3);


            //Act
            brand.BrandPicture = "Test_10.jpg";
            brand.EnglishBrandName = "Ten";
            brand.PersianBrandName = "ده";
            
          
            brand_2.BrandPicture = "Test_11.jpg";
            brand_2.EnglishBrandName = "Eleven";
            brand_2.PersianBrandName = "یازده";
            

            var temp_1 = await _brandsMoqData.BrandsMoqDb()
                .Result.Update(brand , userName);

            var temp_2 = await _brandsMoqData.BrandsMoqDb()
                .Result.Update(brand_2, userName);
                    //Important : This brand does not belong to George , therefor
                    //the test should returns -1


            Assert.Equal(1, temp_1);
            Assert.Equal(-1, temp_2);

        }

        [Theory]
        [InlineData()]

        public async void GetImagesNameByBrandId()
        {
            //Arrange            
            string userName = "George";


            //Act
            var temp_1 = await _brandsMoqData.BrandsMoqDb()
                .Result.GetImagesNameByBrandId(1, userName);

            var temp_2 = await _brandsMoqData.BrandsMoqDb()
                .Result.GetImagesNameByBrandId(3, userName);//This is meaning if a user want to get the image of a 
                                                //brand that the brand 
                                                //is not belonged to that user , the test should returns null

            //Assert
            Assert.Equal("TestPic_1.jpg", temp_1);
            Assert.Null(temp_2);
        }
    }
}

