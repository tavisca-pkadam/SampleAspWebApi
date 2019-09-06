using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using WebApi1.Data;
using WebApi1.Models;
using Xunit;

namespace TestWebApi.Data {
    public class UserDataFixture {
        [Fact]
        public void Test_CreateDummyData_When_Called_Then_UserListCountIsFive () {
            UserData.CreateDummyData ();
            UserData.userList.Count.Should ().Be (5);
        }

        [Fact]
        public void Test_ClearDummyData_When_Called_Then_UserListCountIsZero () {
            UserData.ClearDummyData ();
            UserData.userList.Count.Should ().Be (0);
        }

        [Fact]
        public void Test_GetSingle_When_NotExistingId_Returns_Null () {
            UserData.CreateDummyData ();
            UserData userData = new UserData ();
            UserModel user = userData.GetSingle (100);

            user.Should ().BeNull ();
        }

        [Fact]
        public void Test_GetSingle_When_DummyDataCreated_Returns_UserModel () {
            UserData.CreateDummyData ();
            UserData userData = new UserData ();
            UserModel user = userData.GetSingle (1);

            UserModel expectedUserModel = new UserModel { Id = 1, FirstName = "Paresh", LastName = "Kadam", Address = "Pune", Age = 22 };

            user.Should ().BeEquivalentTo (expectedUserModel);
        }

        [Fact]
        public void Test_GetList_When_EmptyData_Returns_Null () {
            UserData.ClearDummyData ();
            UserData userData = new UserData ();
            var user = userData.GetList ();

            user.Should ().BeNull ();
        }

        [Fact]
        public void Test_GetList_When_Called_Returns_UserModelList () {
            UserData.ClearDummyData ();
            UserData.CreateDummyData ();
            UserData userData = new UserData ();

            var user = userData.GetList ();

            user.Count.Should ().Be (5);
        }

        [Fact]
        public void Test_Create_When_Called_Returns_CreatedUserModel () {
            UserData.ClearDummyData ();
            UserData.CreateDummyData ();
            UserData userData = new UserData ();

            var newUser = new UserModel {
                FirstName = "Aatif",
                LastName = "Siddique",
                Address = "Pune",
                Age = 21,
                Id = 6
            };
            var actualUser = userData.Create (newUser);

            actualUser.Should ().BeEquivalentTo (newUser);
        }

        [Fact]
        public void Test_Update_When_Called_Returns_UpdatedUserModel () {
            UserData.ClearDummyData ();
            UserData.CreateDummyData ();

            var newUser = new UserModel {
                FirstName = "Dharni",
                LastName = "Siddique",
                Address = "Nagpur",
                Age = 24,
                Id = 5
            };
            UserData userData = new UserData ();
            var actualUser = userData.Update (5, newUser);

            actualUser.Should ().BeEquivalentTo (newUser);
        }

        [Fact]
        public void Test_Delete_When_Called_Returns_UpdatedUserModel () {
            UserData.ClearDummyData ();
            UserData.CreateDummyData ();
            UserData userData = new UserData ();

            userData.Delete (5);
            UserData.userList.Count.Should ().Be (4);
        }

    }
}