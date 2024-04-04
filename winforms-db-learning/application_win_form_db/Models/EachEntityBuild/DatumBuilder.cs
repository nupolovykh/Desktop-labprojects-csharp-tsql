namespace application_win_form_db.Models.EachEntityBuild
{
	internal static class DatumBuilder
	{
		public static void DatumBuild(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Datum>(entity =>
			{
				entity.HasKey(e => e.DataId)
					.HasName("PK__Data__F5A76B3B184E1832");

				entity.Property(e => e.DataId)
					.ValueGeneratedNever()
					.HasColumnName("data_id");

				entity.Property(e => e.ApparentResistivity)
					.HasColumnType("decimal(18, 6)")
					.HasColumnName("apparent_resistivity");

				entity.Property(e => e.EffectiveThickness)
					.HasColumnType("decimal(18, 6)")
					.HasColumnName("effective_thickness");

				entity.Property(e => e.MeasurementId).HasColumnName("measurement_id");

				entity.HasOne(d => d.Measurement)
					.WithMany(p => p.Data)
					.HasForeignKey(d => d.MeasurementId)
					.HasConstraintName("FK__Data__measuremen__4AB81AF0");
			});

			modelBuilder.Entity<Datum>().HasData(
				new Datum { DataId = 1, MeasurementId = 1, ApparentResistivity = 8234.275678m, EffectiveThickness = 9830.465698m },
				new Datum { DataId = 2, MeasurementId = 1, ApparentResistivity = 9682.135970m, EffectiveThickness = 2359.346638m },
				new Datum { DataId = 3, MeasurementId = 1, ApparentResistivity = -1467.141658m, EffectiveThickness = 1234.215608m },
				new Datum { DataId = 4, MeasurementId = 1, ApparentResistivity = 7835.783123m, EffectiveThickness = 4562.892145m },
				new Datum { DataId = 5, MeasurementId = 2, ApparentResistivity = 3546.912233m, EffectiveThickness = 8765.084456m },
				new Datum { DataId = 6, MeasurementId = 2, ApparentResistivity = 8234.275678m, EffectiveThickness = 9830.465698m },
				new Datum { DataId = 7, MeasurementId = 2, ApparentResistivity = 9682.135970m, EffectiveThickness = 2359.346638m },
				new Datum { DataId = 8, MeasurementId = 2, ApparentResistivity = -5467.141658m, EffectiveThickness = 1234.215608m },
				new Datum { DataId = 9, MeasurementId = 3, ApparentResistivity = 7835.783123m, EffectiveThickness = 4562.892145m },
				new Datum { DataId = 10, MeasurementId = 3, ApparentResistivity = 3546.912233m, EffectiveThickness = 8765.084456m },
				new Datum { DataId = 11, MeasurementId = 3, ApparentResistivity = -3546.912233m, EffectiveThickness = 8765.084456m },
				new Datum { DataId = 12, MeasurementId = 4, ApparentResistivity = 8234.275678m, EffectiveThickness = 9830.465698m },
				new Datum { DataId = 13, MeasurementId = 4, ApparentResistivity = 9682.135970m, EffectiveThickness = 2359.346638m },
				new Datum { DataId = 14, MeasurementId = 6, ApparentResistivity = 1467.141658m, EffectiveThickness = 1234.215608m },
				new Datum { DataId = 15, MeasurementId = 6, ApparentResistivity = 7835.783123m, EffectiveThickness = 4562.892145m },
				new Datum { DataId = 16, MeasurementId = 6, ApparentResistivity = 3546.912233m, EffectiveThickness = 8765.084456m },
				new Datum { DataId = 17, MeasurementId = 6, ApparentResistivity = -6234.567890m, EffectiveThickness = 3800.123456m },
				new Datum { DataId = 18, MeasurementId = 6, ApparentResistivity = 3578.987654m, EffectiveThickness = 2945.678901m },
				new Datum { DataId = 19, MeasurementId = 6, ApparentResistivity = 1835.783123m, EffectiveThickness = 4562.892145m }
			);

		}
	}
}
