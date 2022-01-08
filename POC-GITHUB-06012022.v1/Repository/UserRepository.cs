using POC_GITHUB_06012022.v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            //var users = new List<User>();
            //users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
            //users.Add(new User { Id = 2, Username = "robin", Password = "robin", Role = "employee" });

            return new User { Id = 1, Username = username, Password = password, Role = "manager" };
        }
    }
}
