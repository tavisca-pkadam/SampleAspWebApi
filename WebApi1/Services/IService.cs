using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.Services {
    public interface IService {
        Response GetSingle (int id);

        Response GetList ();

        Response Create (UserModel user);

        Response Update (int id, UserModel user);

        Response Delete (int id);

    }
}