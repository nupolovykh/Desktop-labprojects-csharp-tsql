using Lab4.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services
{
	public interface IDbWorker
	{
		public IEnumerable<Product> Products { get; }

		public IEnumerable<Material> Materials { get; }

		public void SaveChanges();
	}
}
