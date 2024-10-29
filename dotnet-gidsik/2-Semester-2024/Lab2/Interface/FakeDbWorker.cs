using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class FakeDbWorker : IDbWorker
    {
        public bool Entrance(string login, string password)
        {
            return false;
        }

        public void Registration(string login, string password)
        {
            return;
        }

        public bool Validation(string login)
        {
            return false;
        }
    }
}
