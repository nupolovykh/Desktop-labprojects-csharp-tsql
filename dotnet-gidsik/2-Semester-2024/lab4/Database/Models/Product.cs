using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Database
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; } = 0M;
		public int MaterialId { get; set; }
		public Material? Material { get; set; }

	}
}
