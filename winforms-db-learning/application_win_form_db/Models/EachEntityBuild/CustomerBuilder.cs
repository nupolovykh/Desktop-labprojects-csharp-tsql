
namespace application_win_form_db.Models.EachEntityBuild
{
	internal static class CustomerBuilder
	{
		public static void CustomerBuild(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>(entity =>
			{
				entity.Property(e => e.CustomerId)
					.ValueGeneratedNever()
					.HasColumnName("customer_id");

				entity.Property(e => e.Address)
					.HasMaxLength(100)
					.HasColumnName("address");

				entity.Property(e => e.City)
					.HasMaxLength(100)
					.HasColumnName("city");

				entity.Property(e => e.Name)
					.HasMaxLength(100)
					.HasColumnName("name");

				entity.Property(e => e.Phone)
					.HasMaxLength(100)
					.HasColumnName("phone");
			});

			modelBuilder.Entity<Customer>().HasData(
				new Customer { CustomerId = 1, Name = "John Smith", Address = "123 Main St.", City = "Los Angeles", Phone = "+1-323-456-7890" },
				new Customer { CustomerId = 2, Name = "Jane Doe", Address = "456 Oak Ave.",	City = "New York", Phone = "+1-646-123-4567" },
				new Customer { CustomerId = 3, Name = "Mary Johnson", Address = "789 Pine St.", City = "Chicago", Phone = "+1-773-234-5678" }
			);
		}
	}
}
