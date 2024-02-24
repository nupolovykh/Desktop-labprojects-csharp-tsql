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

        public RealDbWorker(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool Entrance(string login, string password)
        {
            MessageBox.Show("entrance");
            return false;
        }

        public void Registration(string login, string password)
        {
            MessageBox.Show("registration");
        }

        public bool Validation(string login)
        {
            MessageBox.Show("validation passed");
            return false;
        }
    }
}
