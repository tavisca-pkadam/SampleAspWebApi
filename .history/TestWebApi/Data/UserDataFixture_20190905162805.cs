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
            var user = UserData.GetList();

            user.Should().BeNull();
        }

        [Fact]
        public void Test_GetList_When_Called_Returns_UserModelList()
        {
            UserData.CreateDummyData();
            UserModel user = UserData.GetListList();

            

            ;
        }

    }
}
