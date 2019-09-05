using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using WebApi1.Data;
using WebApi1.Models;

namespace TestWebApi.Data
{
    public class UserDataFixture
    {
        [Fact]
        public void Test_GetSingle_When_NotExistingId_Returns_Null()
        {
            UserData.CreateDummyData();
            UserModel user = UserData.GetSingle(100);

            user.Should().BeNull();
        }

        [Fact]
        public void Test_GetSingle_When_DummyDataCreated_Returns_UserModel()
        {
            UserData.CreateDummyData();
            UserModel user = UserData.GetSingle(1);

            UserModel expectedUserModel = new UserModel { Id = 1, FirstName = "Paresh", LastName = "Kadam", Address = "Pune", Age = 22 };

            user.Should().BeEquivalentTo(expectedUserModel);
        }

        [Fact]
        public void Test_GetList_When_EmptyData_Returns_Null()
        {
            UserData.ClearDummyData();
            var user = UserData.GetList();

            user.Should().BeNull();
        }

        [Fact]
        public void Test_GetList_When_Called_Returns_UserModelList()
        {
            UserData.ClearDummyData();
            UserData.CreateDummyData();

            var user = UserData.GetList();

            user.Count.Should().Be(5);
        }

        [Fact]
        public void Test_Create_When_Called_Returns_CreatedUserModel()
        {
            UserData.ClearDummyData();
            UserData.CreateDummyData();

            var newUser = new UserModel {
                FirstName = "Aatif",
                LastName = "Siddique",
                Address = "Pune",
                Age = 21,
                Id = 6
            };
            var actualUser = UserData.Create(newUser);

            actualUser.Should().BeEquivalentTo(newUser);
        }

        [Fact]
        public void Test_Update_When_Called_Returns_UpdatedUserModel()
        {
            UserData.ClearDummyData();
            UserData.CreateDummyData();
            
            var newUser = new UserModel {
                FirstName = "Dharni",
                LastName = "Siddique",
                Address = "Nagpur",
                Age = 24,
                Id = 5
            };
            var actualUser = UserData.Update(5, newUser);

            actualUser.Should().BeEquivalentTo(newUser);
        }

        [Fact]
        public void Test_Delete_When_Called_Returns_UpdatedUserModel()
        {
            UserData.CreateDummyData();
            UserData.Delete(5);
            UserData.userList.Count.Should().Be(4);
        }

    }
}
