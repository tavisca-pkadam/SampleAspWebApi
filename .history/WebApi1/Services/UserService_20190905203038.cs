using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Data;
using WebApi1.Models;

namespace WebApi1.Services
{
    public class UserService
    {
        UserData userData;

        public UserService()
        {
            userData = new UserData();
        }
        public Response GetSingle(int id)
        {
            // Non existing data sends null
            // valid id return valid single user
            var response = new Response();

            if (id < 1)
            {
                response.data = null;
                response.message = "Invalid Index - Should Not Be Negative";
                response.statusCode = 300;
            }
            else
            {
                var user = UserData.GetSingle(id);
                if (user == null)
                {
                    response.data = user;
                    response.message = "Not Found User - Please Search For Another User";
                    response.statusCode = 400;
                }
                else
                {
                    response.data = user;
                    response.message = "Success";
                    response.statusCode = 200;
                }
            }

            return response;

            // negative index sends null
            // send invalid message if data sends null
        }

        public Response GetList()
        {
            // Todo Pagination
            var response = new Response();
            var userList = UserData.GetList();
            if (userList.Count > 0)
            {
                response.data = userList;
                response.message = "Success";
                response.statusCode = 200;
            }
            else
            {
                response.data = userList;
                response.message = "No User Data Found";
                response.statusCode = 200;
            }

            return response;
            // Test_GetList_When_EmptyData_Returns_Null
            // Test_Create_When_Called_Returns_CreatedUserModel

            // send invalid message if data sends null
        }

        public Response Create(UserModel user)
        {
            // Test_Create_When_Called_Returns_CreatedUserModel
            var response = new Response();

            var validateAddress = user.Address.Length > 1;
            var validateFirstName = user.Address.Length > 1;
            var validateLastName = user.Address.Length > 1;
            var validateAge = user.Age < 18;

            response.data = user;

            if (user.Age < 19)
            {
                response.message = "User Age To be 18+";
                response.statusCode = 100;
            }
            else if (validateAddress && validateFirstName && validateFirstName && validateLastName)
            {
                response.message = "Incomplete Data";
                response.statusCode = 100;
            }
            else
            {
                response.data = UserData.Create(user);
                response.message = "Success";
                response.statusCode = 200;
            }
            return response;
            // validate user data and then send to data
        }

        public void Update(int id, UserModel user)
        {
            // Test_Update_When_Called_Returns_UpdatedUserModel
            var response = new Response();

            var validateAddress = user.Address.Length > 1;
            var validateFirstName = user.Address.Length > 1;
            var validateLastName = user.Address.Length > 1;
            var validateAge = user.Age < 18;

            response.data = user;

            if (user.Age < 18)
            {
                response.message = "User Age To be 18+";
                response.statusCode = 100;
            }
            else if (validateAddress && validateFirstName && validateFirstName && validateLastName)
            {
                response.message = "Incomplete Data";
                response.statusCode = 100;
            }
            else
            {
                response.data = UserData.Update(id, user);
                response.message = "Success";
                response.statusCode = 200;
            }
            return response;
            // validata user data and then send to data
        }

        public void Delete(int id)
        {
            UserData.Delete(id);
            // Test_Delete_When_Called_Returns_UpdatedUserModel
            // validate id exists and send to user data
            // Invalid 
        }
    }
}
