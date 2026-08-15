using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Database
{
	public class Material
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public IEnumerable<Product>? Products { get; set; }

	}
}
