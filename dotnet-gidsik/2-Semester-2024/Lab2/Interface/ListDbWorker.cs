using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class ListDbWorker : IDbWorker
    {
        private static List<User> _users = new List<User> { new User { Id = 1, Login = "admin", Password = "admin"} };
        private static int _id = 2;

        public bool Entrance(string login, string password)
        {
            var user = _users.Find(user => user.Login == login);

            if(user != null && user.Password == password)
            {
                return true;
            }
            else { return false; }
        }

        public void Registration(string login, string password)
        {
            _users.Add(new User{ Id = _id++, Login = login, Password = password});
        }

        public bool Validation(string login)
        {
            var user = _users.Find(user => user.Login == login);

            if (user != null)
            {
                return true;
            }
            else { return false; }
        }
    }
}
