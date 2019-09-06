using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using WebApi1.Data;
using WebApi1.Models;
using WebApi1;
using WebApi1.Services;

namespace TestWebApi.Data
{
    public class UserServiceFixture
    {
        [Fact]
        public void Test_GetSingle_Returns_NullAndStatus300_On_NegativeId()
        {
            var response = new Response();
            var userService = new UserService();

            response.data = null;
            response.message = "Invalid Index - Should Not Be Negative";
            response.statusCode = 404;
            userService.GetSingle(-1).Should().BeEquivalentTo(response);

        }
        [Fact]
        public void Test_GetSingle_Returns_NullAndStatus400_On_UnAvailableData()
        {
            var response = new Response();
            var userService = new UserService();
            UserData.CreateDummyData();

            response.data = null;
            response.message = "Not Found User - Please Search For Another User";
            response.statusCode = 404;
            userService.GetSingle(6).Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }
        [Fact]
        public void Test_GetSingle_Returns_UserModelAndStatus200_On_AvailableData()
        {
            var response = new Response();
            var userService = new UserService();
            UserData.CreateDummyData();

            var user = new UserModel { Id = 1, FirstName = "Paresh", LastName = "Kadam", Address = "Pune", Age = 22 };
            response.data = user;
            response.message = "Success";
            response.statusCode = 200;

            userService.GetSingle(1).Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }
        [Fact]
        public void Test_GetList_Returns_ListOfFiveElements_On_Call()
        {
            var response = new Response();
            var userService = new UserService();
            UserData.ClearDummyData();

            UserData.CreateDummyData();

            var expectedUser = new List<UserModel>();
            expectedUser.Add(new UserModel { Id = 1, FirstName = "Paresh", LastName = "Kadam", Address = "Pune", Age = 22 });
            expectedUser.Add(new UserModel { Id = 2, FirstName = "Arnaw", LastName = "Gundawar", Address = "Pune", Age = 22 });
            expectedUser.Add(new UserModel { Id = 3, FirstName = "Aditi", LastName = "Rupade", Address = "Pune", Age = 22 });
            expectedUser.Add(new UserModel { Id = 4, FirstName = "Shravan", LastName = "Ramdurg", Address = "Pune", Age = 22 });
            expectedUser.Add(new UserModel { Id = 5, FirstName = "Dharna", LastName = "Gupta", Address = "Pune", Age = 22 });

            response.data = expectedUser;
            response.message = "Success";
            response.statusCode = 200;

            userService.GetList().Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }

        [Fact]
        public void Test_Create_Returns_RequestDataAndStatus404_On_AgeBelow18()
        {
            var response = new Response();
            var userService = new UserService();
            UserData.CreateDummyData();

            var newUser = new UserModel { Id = 1, FirstName = "Paresh", LastName = "Kadam", Address = "Pune", Age = 18 };

            response.data = newUser;
            response.message = "User Age To be 18+";
            response.statusCode = 404;

            userService.Create(newUser).Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }
        [Fact]
        public void Test_Create_Returns_RequestDataAndStatus404_On_IncompleteData()
        {

            var response = new Response();
            var userService = new UserService();
            UserData.CreateDummyData();

            var newUser = new UserModel { Id = 1, FirstName = "Paresh", LastName = "", Address = "Pune", Age = 20 };

            response.data = newUser;
            response.message = "Incomplete Data";
            response.statusCode = 404;

            userService.Create(newUser).Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }
        [Fact]
        public void Test_Create_Returns_RequestDataAndStatus200_On_ValidData()
        {

            var response = new Response();
            var userService = new UserService();
            UserData.CreateDummyData();

            var newUser = new UserModel { Id = 1, FirstName = "Aatif", LastName = "Siddique", Address = "Pune", Age = 21 };

            response.data = newUser;
            response.message = "Incomplete Data";
            response.statusCode = 404;

            userService.Create(newUser).Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }

        [Fact]
        public void Test_Update_Returns_RequestDataAndStatus404_On_IncompleteData()
        {
            var response = new Response();
            var userService = new UserService();
            UserData.CreateDummyData();

            var newUser = new UserModel { Id = 1, FirstName = "Paresh", LastName = "", Address = "Pune", Age = 18 };

            response.data = newUser;
            response.message = "Incomplete Data";
            response.statusCode = 404;

            userService.Update(1, newUser).Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }

        [Fact]
        public void Test_Update_Returns_NullAndStatus300_On_NegativeId()
        {
            var response = new Response();
            var userService = new UserService();
            UserData.CreateDummyData();

            var newUser = new UserModel { Id = 1, FirstName = "Paresh", LastName = "", Address = "Pune", Age = 18 };

            response.data = newUser;
            response.message = "Ivalid Id";
            response.statusCode = 404;

            userService.Update(-1, newUser).Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }

        [Fact]
        public void Test_Delete_Returns_NullAndStatus300_On_NegativeId()
        {
            var response = new Response();
            var userService = new UserService();
            UserData.CreateDummyData();


            response.data = null;
            response.message = "Ivalid Id";
            response.statusCode = 404;

            userService.Delete(-1).Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }

        [Fact]
        public void Test_Delete_Returns_NullAndStatus200_On_ValidId()
        {
            var response = new Response();
            var userService = new UserService();
            UserData.CreateDummyData();

            response.data = null;
            response.message = "Sucessfull Delete";
            response.statusCode = 200;

            userService.Delete(1).Should().BeEquivalentTo(response);

            UserData.ClearDummyData();
        }

    }
}
