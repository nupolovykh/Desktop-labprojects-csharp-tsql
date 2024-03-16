
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
				new Datum { DataId = 1, MeasurementId = 1, ApparentResistivity = 823456789012.275678m, EffectiveThickness = 983056789012.465698m },
				new Datum { DataId = 2, MeasurementId = 1, ApparentResistivity = 968260789096.135970m, EffectiveThickness = 235928785428.346638m },
				new Datum { DataId = 3, MeasurementId = 1, ApparentResistivity = 146704889063.141658m, EffectiveThickness = 123456756039.215608m },
				new Datum { DataId = 4, MeasurementId = 1, ApparentResistivity = 783545778764.783123m, EffectiveThickness = 456287638910.892145m },
				new Datum { DataId = 5, MeasurementId = 1, ApparentResistivity = 354678965428.912233m, EffectiveThickness = 876523987451.084456m }
			);

		}
	}
}
