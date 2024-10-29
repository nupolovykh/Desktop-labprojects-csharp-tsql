using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public interface IDbWorker
    {
        public bool Entrance(string login, string password);

        public void Registration(string login, string password);

        public bool Validation(string login);
    }
}
