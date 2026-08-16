using Lab3.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Services.Interface
{
    public interface IDbWorker
    {
        IEnumerable<Material> Materials { get; }
        IEnumerable<Product> Products { get; }
        public void SaveChanges();
    }
}
