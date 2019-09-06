using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.Data {
    interface IData {
        UserModel GetSingle (int id);

        List<UserModel> GetList ();

        UserModel Create (UserModel user);

        UserModel Update (int id, UserModel user);

        void Delete (int id);
    }
}