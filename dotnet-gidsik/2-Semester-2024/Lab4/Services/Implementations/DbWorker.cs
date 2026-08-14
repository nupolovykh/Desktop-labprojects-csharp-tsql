using Lab4.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services
{
	internal class DbWorker : IDbWorker
	{
		private readonly List<Material> _materials;
		private readonly List<Product> _products;

		private AppDbContext _context;

		public DbWorker (AppDbContext context) 
		{
			_context = context;

			_materials = context.Materials.ToList();
			//.Include(m => m.Products).ToList();

			_products = context.Products.ToList();
			//.Include(p => p.Material).ToList();
		}

		public IEnumerable<Product> Products => _products;

		public IEnumerable<Material> Materials => _materials;

		public void SaveChanges() => _context.SaveChanges();

	}
}
