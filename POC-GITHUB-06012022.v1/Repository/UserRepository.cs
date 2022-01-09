using POC_GITHUB_06012022.v1.Entity;

namespace POC_GITHUB_06012022.v1.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password, string email)
        {
            return new User { IdUser = 1, Username = username, Password = password, Role = "manager"  , Email = email};
        }
    }
}
