namespace MyWinFormsAppForDb.Models.EachEntityBuild
{
	internal static class MeasurementsBuilder
	{
		public static void MeasurementsBuild(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Measurement>(entity =>
			{
				entity.Property(e => e.MeasurementId)
					.ValueGeneratedNever()
					.HasColumnName("measurement_id");

				entity.Property(e => e.MeasurementDate)
					.HasColumnType("date")
					.HasColumnName("measurement_date");

				entity.Property(e => e.MeasurementTime).HasColumnName("measurement_time");

				entity.Property(e => e.Notes)
					.HasColumnType("text")
					.HasColumnName("notes");

				entity.Property(e => e.PicketId).HasColumnName("picket_id");

				entity.HasOne(d => d.Picket)
					.WithMany(p => p.Measurements)
					.HasForeignKey(d => d.PicketId)
					.HasConstraintName("FK__Measureme__picke__4CA06362");
			});

			modelBuilder.Entity<Measurement>().HasData(
				new Measurement { MeasurementId = 1, MeasurementDate = new DateTime(2024, 3, 15),
					MeasurementTime = new TimeSpan(14, 30, 0), PicketId = 1, Notes = "Detailed notes for Measurement 1." },
				new Measurement { MeasurementId = 2, MeasurementDate = new DateTime(2024, 4, 15), 
					MeasurementTime = new TimeSpan(15, 36, 10), PicketId = 3, Notes = "Detailed notes for Measurement 11." },
				new Measurement { MeasurementId = 3, MeasurementDate = new DateTime(2024, 5, 15), 
					MeasurementTime = new TimeSpan(11, 20, 54), PicketId = 6, Notes = "Detailed notes for Measurement 12." },
				new Measurement { MeasurementId = 4, MeasurementDate = new DateTime(2024, 6, 15), 
					MeasurementTime = new TimeSpan(5, 13, 44), PicketId = 7, Notes = "Detailed notes for Measurement 13." },
				new Measurement { MeasurementId = 6, MeasurementDate = new DateTime(2024, 3, 17),
					MeasurementTime = new TimeSpan(11, 20, 0), PicketId = 3, Notes = "Detailed notes for Measurement 3." },


				new Measurement { MeasurementId = 5, MeasurementDate = new DateTime(2024, 3, 16),
					MeasurementTime = new TimeSpan(15, 45, 0), PicketId = 2, Notes = "Detailed notes for Measurement 2." },
				new Measurement { MeasurementId = 9, MeasurementDate = new DateTime(2024, 3, 17),
					MeasurementTime = new TimeSpan(10, 0, 0), PicketId = 4, Notes = "Detailed notes for Measurement 4." },
				new Measurement { MeasurementId = 8, MeasurementDate = new DateTime(2024, 3, 19),
					MeasurementTime = new TimeSpan(12, 15, 0), PicketId = 5, Notes = "Detailed notes for Measurement 5." }
			);

		}
	}
}
