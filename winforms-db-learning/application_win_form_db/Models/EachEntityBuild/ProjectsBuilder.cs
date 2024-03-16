
namespace application_win_form_db.Models.EachEntityBuild
{
	internal static class ProjectBuilder
	{
		public static void ProjectBuild(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Project>(entity =>
			{
				entity.Property(e => e.ProjectId)
					.ValueGeneratedNever()
					.HasColumnName("project_id");

				entity.Property(e => e.CustomerId).HasColumnName("customer_id");

				entity.Property(e => e.Description)
					.HasColumnType("text")
					.HasColumnName("description");

				entity.Property(e => e.EndDate)
					.HasColumnType("datetime")
					.HasColumnName("end_date");

				entity.Property(e => e.Name)
					.HasMaxLength(100)
					.HasColumnName("name");

				entity.Property(e => e.StartDate)
					.HasColumnType("datetime")
					.HasColumnName("start_date");

				entity.Property(e => e.Status)
					.HasMaxLength(100)
					.HasColumnName("status");

				entity.HasOne(d => d.Customer)
					.WithMany(p => p.Projects)
					.HasForeignKey(d => d.CustomerId)
					.HasConstraintName("FK__Projects__custom__5070F446");
			});

			modelBuilder.Entity<Project>().HasData(
				new Project { ProjectId = 1, CustomerId = 1, Description = "Geophysical survey for underground utilities",
					EndDate = new DateTime(2024, 8, 31), Name = "Utility Survey Project", StartDate = new DateTime(2024, 8, 1), Status = "Ongoing" },
				new Project { ProjectId = 2, CustomerId = 2, Description = "Seismic data collection for geological analysis",
					EndDate = new DateTime(2024, 12, 31), Name = "Seismic Analysis Project", StartDate = new DateTime(2024, 9, 1), Status = "Planned" },
				new Project { ProjectId = 3, CustomerId = 1, Description = "Magnetic anomaly mapping for archaeological study",
					EndDate = new DateTime(2025, 3, 31), Name = "Archaeological Mapping Project", StartDate = new DateTime(2025, 1, 1), Status = "In Progress" },
				new Project { ProjectId = 4, CustomerId = 3, Description = "Electrical resistivity profiling for environmental research",
					EndDate = new DateTime(2024, 11, 30), Name = "Environmental Profiling Project", StartDate = new DateTime(2024, 10, 1), Status = "Completed" }
			);

		}
	}
}
