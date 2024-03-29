using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.Data {
    public class UserData : IData {
        public static List<UserModel> userList = new List<UserModel> ();

        public static void CreateDummyData () {
            if (userList.Count <5) {
                userList.Add (new UserModel { Id = 1, FirstName = "Paresh", LastName = "Kadam", Address = "Pune", Age = 22 });
                userList.Add (new UserModel { Id = 2, FirstName = "Arnaw", LastName = "Gundawar", Address = "Pune", Age = 22 });
                userList.Add (new UserModel { Id = 3, FirstName = "Aditi", LastName = "Rupade", Address = "Pune", Age = 22 });
                userList.Add (new UserModel { Id = 4, FirstName = "Shravan", LastName = "Ramdurg", Address = "Pune", Age = 22 });
                userList.Add (new UserModel { Id = 5, FirstName = "Dharna", LastName = "Gupta", Address = "Pune", Age = 22 });
            }
        }

        public static void ClearDummyData () {
            userList = new List<UserModel> ();
        }

        public UserData () {
            //CreateDummyData();
        }

        public UserModel GetSingle (int id) {
            var user = userList.Where (u => u.Id == id).FirstOrDefault ();
            return user;
        }

        public List<UserModel> GetList () {
            var user = userList.Count > 0 ? userList : null;
            return user;
        }

        public UserModel Create (UserModel user) {
            user.Id = userList.Count + 1;
            userList.Add (user);
            return userList.Last ();
        }

        public UserModel Update (int id, UserModel user) {
            // not found userModel check

            user.Id = id;
            int userElementIndex = userList.FindIndex (x => x.Id == id);
            userList[userElementIndex] = user;
            return userList[userElementIndex];
        }

        public void Delete (int id) {
            userList = userList.Where (u => u.Id != id)
                .Select (u => u)
                .ToList ();
        }
    }
}