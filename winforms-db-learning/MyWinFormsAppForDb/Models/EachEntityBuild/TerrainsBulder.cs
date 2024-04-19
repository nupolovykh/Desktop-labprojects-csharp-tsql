
namespace MyWinFormsAppForDb.Models.EachEntityBuild
{
	internal static class TerrainBuilder
	{
		public static void TerrainBuild(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Terrain>(entity =>
			{
				entity.Property(e => e.TerrainId)
					.ValueGeneratedNever()
					.HasColumnName("terrain_id");

				entity.Property(e => e.Latitude)
					.HasColumnType("decimal(9, 6)")
					.HasColumnName("latitude");

				entity.Property(e => e.Longitude)
					.HasColumnType("decimal(9, 6)")
					.HasColumnName("longitude");

				entity.Property(e => e.Name)
					.HasMaxLength(100)
					.HasColumnName("name");

				entity.Property(e => e.ProjectId).HasColumnName("project_id");

				entity.Property(e => e.SizeInSquareMeters).HasColumnName("size_in_square_meters");

				entity.Property(e => e.TerrainType)
					.HasMaxLength(100)
					.HasColumnName("terrain_type");

				entity.HasOne(d => d.Project)
					.WithMany(p => p.Terrains)
					.HasForeignKey(d => d.ProjectId)
					.HasConstraintName("FK__Terrains__projec__52593CB8");
			});

			modelBuilder.Entity<Terrain>().HasData(
				new Terrain { TerrainId = 1, Latitude = 40.730610m, Longitude = -73.935242m, Name = "Urban Utility Area",
					ProjectId = 1, SizeInSquareMeters = 5000, TerrainType = "Urban" },
				new Terrain { TerrainId = 2, Latitude = 34.052235m, Longitude = -118.243683m, Name = "Seismic Activity Zone",
					ProjectId = 2, SizeInSquareMeters = 7500, TerrainType = "Geological" },
				new Terrain { TerrainId = 3, Latitude = 51.507351m, Longitude = -0.127758m, Name = "Archaeological Excavation Site",
					ProjectId = 3, SizeInSquareMeters = 4000, TerrainType = "Historical" },
				new Terrain { TerrainId = 4, Latitude = 48.856613m, Longitude = 2.352222m, Name = "Environmental Conservation Zone",
					ProjectId = 4, SizeInSquareMeters = 6000, TerrainType = "Ecological" }
			);

		}
	}
}
