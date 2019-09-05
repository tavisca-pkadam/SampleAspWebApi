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
            //
            
            // send invalid message if data sends null
        }

        public void GetList()
        {
            // later on pagination logic
            // send invalid message if data sends null
        }

        public void Create(UserModel user)
        {
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
