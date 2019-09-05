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
            
            if(id < 1){
                return 
            }
            
            // negative index sends null
            // send invalid message if data sends null
        }

        public void GetList()
        {
            // Todo Pagination
            // Test_GetList_When_EmptyData_Returns_Null
            // Test_Create_When_Called_Returns_CreatedUserModel
            
            // send invalid message if data sends null
        }

        public void Create(UserModel user)
        {
            // Test_Create_When_Called_Returns_CreatedUserModel
            
            // validate user data and then send to data
        }

        public void Update(int id, UserModel user)
        {
            // Test_Update_When_Called_Returns_UpdatedUserModel

            // validata user data and then send to data
        }

        public void Delete(int id)
        {
            // Test_Delete_When_Called_Returns_UpdatedUserModel
            // validate id exists and send to user data
            // Invalid 
        }
    }
}
