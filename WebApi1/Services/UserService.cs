using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Data;
using WebApi1.Models;

namespace WebApi1.Services {
    public class UserService : IService {
        public static UserData userData = new UserData ();
        public UserService () {
            UserData.CreateDummyData ();
        }

        private void CreateSuccessResponse(Object responseObject, Response response)
        {
           
                response.data = responseObject;
                response.message.Add("Success");
                response.statusCode = 200;
        }

        public Response GetSingle (int id) {

            var response = new Response ();

            if (UserValidation.TryValidateId(id, response.message)) {
                var user = userData.GetSingle(id);
                if (user == null)
                {
                    response.data = user;
                    response.message.Add("Not Found User - Please Search For Another User");
                    response.statusCode = 404;
                }
                else
                {
                    CreateSuccessResponse(user, response);
                }               
            } else {
                response.data = null;
                response.statusCode = 400;
            }

            return response;
        }

        public Response GetList () {
            // Todo Pagination
            var response = new Response ();
            var userList = userData.GetList ();
            
            if (userList.Count > 0) {
                CreateSuccessResponse(userList, response);
            } else {
                response.data = null;
                response.message.Add ("No User Data Found");
                response.statusCode = 404;
            }

            return response;
        }

        public Response Create (UserModel user) {
            var response = new Response ();
            response.data = user;

            if (UserValidation.TryValidateAllFields(user, response.message)) {
                var createdUser = userData.Create(user);
                CreateSuccessResponse(createdUser, response);
            } else {
                response.statusCode = 400;
            }

            return response;
        }

        public Response Update (int id, UserModel user) {
            var response = new Response ();
            response.data = user;
            if (UserValidation.TryValidateAllFields(user, response.message)) {
                CreateSuccessResponse(userData.Update(id, user), response);
            }
            else {
                response.statusCode = 400;
            }
            return response;
        }

        public Response Delete (int id) {
            var response = new Response ();
            if (id < 0) {
                response.message.Add ("Invalid Id");
                response.statusCode = 400;
            } else {
                userData.Delete(id);
                CreateSuccessResponse(null, response);
            }
            return response;
        }
    }
}