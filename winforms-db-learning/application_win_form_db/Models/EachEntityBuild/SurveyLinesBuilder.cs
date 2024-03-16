
namespace application_win_form_db.Models.EachEntityBuild
{
	internal static class SurveyiLinesBuilder
	{
		public static void SurveyiLinesBuild(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SurveyLine>(entity =>
			{
				entity.Property(e => e.SurveyLineId)
					.ValueGeneratedNever()
					.HasColumnName("survey_line_id");

				entity.Property(e => e.Latitude)
					.HasColumnType("decimal(9, 6)")
					.HasColumnName("latitude");

				entity.Property(e => e.LengthInMeters).HasColumnName("length_in_meters");

				entity.Property(e => e.Longitude)
					.HasColumnType("decimal(9, 6)")
					.HasColumnName("longitude");

				entity.Property(e => e.Name)
					.HasMaxLength(100)
					.HasColumnName("name");

				entity.Property(e => e.TerrainId).HasColumnName("terrain_id");

				entity.HasOne(d => d.Terrain)
					.WithMany(p => p.SurveyLines)
					.HasForeignKey(d => d.TerrainId)
					.HasConstraintName("FK__SurveyLin__terra__5165187F");
			});

			modelBuilder.Entity<SurveyLine>().HasData(
				new SurveyLine { SurveyLineId = 1, Latitude = 40.730610m, Longitude = -73.935242m, LengthInMeters = 1000,
					Name = "Utility Survey Line A", TerrainId = 1},
				new SurveyLine { SurveyLineId = 2, Latitude = 34.052235m, Longitude = -118.243683m, LengthInMeters = 1500,
					Name = "Seismic Survey Line B", TerrainId = 2 },
				new SurveyLine { SurveyLineId = 3, Latitude = 35.6895m, Longitude = 139.6917m, LengthInMeters = 1200,
					Name = "Geophysical Survey Line C", TerrainId = 3 },
				new SurveyLine { SurveyLineId = 4, Latitude = 51.5074m, Longitude = -0.1278m, LengthInMeters = 1800,
					Name = "Topographic Survey Line D", TerrainId = 4 },
				new SurveyLine { SurveyLineId = 5, Latitude = 41.9028m, Longitude = 12.4964m, LengthInMeters = 900,
					Name = "Aerial Survey Line E", TerrainId = 4 }
			);

		}
	}
}
