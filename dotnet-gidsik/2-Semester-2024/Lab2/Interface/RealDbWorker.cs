using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class RealDbWorker : IDbWorker
    {
        private AppDbContext _appDbContext;
        private static int id = 2;

        public RealDbWorker(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool Entrance(string login, string password)
        { 
            var condition = _appDbContext.Users
                .Where(u => u.Login == login && u.Password == password).Any();
            return condition;
        }

        public void Registration(string login, string password)
        {
            _appDbContext.Users.Add(new User {Id = id++, Login = login, Password = password });
            _appDbContext.SaveChanges();
        }

        public bool Validation(string login)
        {
            var condition = _appDbContext.Users
                .Where(u => u.Login == login).Any();
            return !condition;
        }
    }
}
