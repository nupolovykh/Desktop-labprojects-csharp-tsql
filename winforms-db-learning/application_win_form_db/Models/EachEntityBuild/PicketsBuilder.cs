
namespace application_win_form_db.Models.EachEntityBuild
{
	internal static class PicketsBuilder
	{
		public static void PicketsBuild(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Picket>(entity =>
			{
				entity.Property(e => e.PicketId)
					.ValueGeneratedNever()
					.HasColumnName("picket_id");

				entity.Property(e => e.Latitude)
					.HasColumnType("decimal(9, 6)")
					.HasColumnName("latitude");

				entity.Property(e => e.Longitude)
					.HasColumnType("decimal(9, 6)")
					.HasColumnName("longitude");

				entity.Property(e => e.SurveyLineId).HasColumnName("survey_line_id");

				entity.HasOne(d => d.SurveyLine)
					.WithMany(p => p.Pickets)
					.HasForeignKey(d => d.SurveyLineId)
					.HasConstraintName("FK__Pickets__survey___4F7CD00D");
			});

			modelBuilder.Entity<Picket>().HasData(
				new Picket { PicketId = 1, Latitude = 40.730610m, Longitude = -73.935242m, SurveyLineId = 1 },
				new Picket { PicketId = 2, Latitude = 34.052235m, Longitude = -118.243683m, SurveyLineId = 2 },
				new Picket { PicketId = 3, Latitude = 51.507351m, Longitude = -0.127758m, SurveyLineId = 1 },
				new Picket { PicketId = 4, Latitude = 48.856613m, Longitude = 2.352222m, SurveyLineId = 2 },
				new Picket { PicketId = 5, Latitude = 68.856613m, Longitude = 1.812426m, SurveyLineId = 3 }
			);

		}
	}
}
