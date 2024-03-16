
namespace application_win_form_db.Models.EachEntityBuild
{
	internal static class UsersBuilder
	{
		public static void UsersBuild(this ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<User>(entity =>
			{
				entity.Property(e => e.UserId)
					.ValueGeneratedNever()
					.HasColumnName("user_id");

				entity.Property(e => e.Login)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasColumnName("login");

				entity.Property(e => e.Password)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("password");

				entity.Property(e => e.Role)
					.HasMaxLength(50)
					.HasColumnName("role");
			});

			modelBuilder.Entity<User>().HasData(
				new User { UserId = 1, Login = "admin_user", Password = "admin@123", Role = "Admin" },
				new User { UserId = 2, Login = "geologist_user", Password = "geo@456", Role = "Geologist" },
				new User { UserId = 3, Login = "archaeologist_user", Password = "arch@789", Role = "Archaeologist" },
				new User { UserId = 4, Login = "environmentalist_user", Password = "enviro@321", Role = "Environmentalist" }
			);
		}
	}
}
