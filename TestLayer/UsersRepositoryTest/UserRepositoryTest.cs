using Brands.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TestLayer.UsersRepositoryTest
{
    public class UserRepositoryTest: IClassFixture<UserMoqData>
    {
        private IUserMoqData _userMoqData;
        public UserRepositoryTest(UserMoqData userMoqData)
        {
            _userMoqData = userMoqData;
        }

        [Theory]
        [InlineData()]

        public async void LoginOrRegisterUser_Test()
        {
            //Arrange
            var loginViewModel_1 = new LoginViewModel()
            {
                UserName = "Will",
                Password = "Smith",
                RememberMe = true
            };
            var loginViewModel_2 = new LoginViewModel()
            {
                UserName = "Bill",
                Password = "456",
                RememberMe = false
            };
            var loginViewModel_3 = new LoginViewModel()
            {
                UserName = "George",
                Password = "1234",
                RememberMe = false
            };
            //Act
            var temp_1 = await _userMoqData.UserMoqDb()
                .Result.LoginOrRegisterUser(loginViewModel_1);

            var temp_2 = await _userMoqData.UserMoqDb()
                .Result.LoginOrRegisterUser(loginViewModel_2);

            var temp_3 = await _userMoqData.UserMoqDb()
                .Result.LoginOrRegisterUser(loginViewModel_3);




            //Assert
            Assert.Equal(0 , temp_1);//User is new , therefor it is registered and returns its Id (0) ,
                                     // It is ziro because we used ViewModel that it has not UserId
                                     //therefor it returns ziro (In tests this is possible).
            Assert.Equal(2 , temp_2);//User and its password are existed now and only should returns its Id.
            Assert.Equal(-1 , temp_3);//User is existed but its password is not true.
        }


        [Theory]
        [InlineData()]

        public async void RegisterUser()
        {
            //Arrange
            var loginViewModel_1 = new LoginViewModel()
            {
                UserName = "Will",
                Password = "Smith",
                RememberMe = true
            };
           
            //Act
            var temp_1 = await _userMoqData.UserMoqDb()
                .Result.LoginOrRegisterUser(loginViewModel_1);

          




            //Assert
            Assert.Equal(0, temp_1); //User is registered and returns its Id(0) ,
                                     // It is ziro because we used ViewModel that it has not UserId
                                     //therefor it returns ziro (In tests this is possible).
        }


        [Theory]
        [InlineData()]

        public async void GetUserIdByUserName()
        {
          
            //Act
            var temp_1 = await _userMoqData.UserMoqDb()
                .Result.GetUserIdByUserName("Bill");

            //Assert
            Assert.Equal(2, temp_1);
        }

    }
}
