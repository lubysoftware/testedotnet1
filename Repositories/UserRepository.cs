using System.Collections.Generic;
using System.Linq;
using testedotnet1.Entities;

namespace testedotnet1.Repositories
{
    public static class UserRepository
    {
        //Mock usuarios
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { IdUser = 1, UserName = "patinhas", Password = "patinhas", Role = "ceo" });
            users.Add(new User { IdUser = 2, UserName = "donald", Password = "donald", Role = "manager" });
            users.Add(new User { IdUser = 3, UserName = "huginho", Password = "huginho", Role = "developer" });
            users.Add(new User { IdUser = 4, UserName = "zezinho", Password = "zezinho", Role = "developer" });
            users.Add(new User { IdUser = 5, UserName = "luizinho", Password = "luizinho", Role = "developer" });
            return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}