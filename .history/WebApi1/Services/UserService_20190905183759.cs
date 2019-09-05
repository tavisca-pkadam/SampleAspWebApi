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
        public void GetSingle(int id)
        {
            // Non existing data sends null
            // valid id return valid single user
            
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
            // validata user data and then send to data
        }

        public void Delete(int id)
        {
            // validate id exists and send to user data
        }
    }
}
