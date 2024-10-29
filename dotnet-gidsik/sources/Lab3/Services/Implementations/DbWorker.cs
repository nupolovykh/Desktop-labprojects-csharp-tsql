using Lab3.database;
using Lab3.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Services.Implementations
{
    internal class DbWorker : IDbWorker
    {
        private AppDbContext _appDbContext;

        public DbWorker(AppDbContext dBContext) {
            _appDbContext = dBContext;

            _appDbContext.Materials.Load();
            _appDbContext.Products.Load();
            
        }

        public IEnumerable<Material> Materials => _appDbContext.Materials.ToList();
        public IEnumerable<Product> Products => _appDbContext.Products.ToList();

        public void SaveChanges() => _appDbContext.SaveChanges();
    }
}
