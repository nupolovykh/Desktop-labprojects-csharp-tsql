using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Models.Database.Entity
{
	public class Role
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[InverseProperty("Role")]
		public ICollection<User> Users { get; set; }
	}
}
