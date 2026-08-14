
namespace MyWinFormsAppForDb.Models.EachEntityBuild
{
	internal static class EquipmentBuilder
	{
		public static void EquipmentBuild(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Equipment>(entity =>
			{
				entity.HasIndex(e => e.SurveyLineId, "UQ__Equipmen__32CCE920A289D4BB")
					.IsUnique();

				entity.Property(e => e.EquipmentId)
					.ValueGeneratedNever()
					.HasColumnName("equipment_id");

				entity.Property(e => e.Description)
					.HasColumnType("text")
					.HasColumnName("description");

				entity.Property(e => e.Name)
					.HasMaxLength(100)
					.HasColumnName("name");

				entity.Property(e => e.SurveyLineId).HasColumnName("survey_line_id");

				entity.HasOne(d => d.SurveyLine)
					.WithOne(p => p.Equipment)
					.HasForeignKey<Equipment>(d => d.SurveyLineId)
					.HasConstraintName("fk_equipment_surveyline");
			});

			modelBuilder.Entity<Equipment>().HasData(
				new Equipment { EquipmentId = 1, Name = "ElectraScan Pro", SurveyLineId = 1, Description = "The ElectraScan Pro is a cutting-edge" +
					" electrical tomography device designed for high-precision" +" imaging of internal structures."},
				new Equipment { EquipmentId = 2, Name = "VoltVision Elite", SurveyLineId = 2, Description = "The VoltVision Elite is a sophisticated" +
					" electrical tomography system that offers real-time monitoring and analysis capabilities."},
				new Equipment { EquipmentId = 3, Name = "OhmSense Ultra", SurveyLineId = 3, Description = "The OhmSense Ultra is a compact and portable" +
					" electrical tomography device suitable for field surveys and on-site inspections."},
				new Equipment { EquipmentId = 4, Name = "CurrentWave Prodigy", SurveyLineId = 4, Description = "The CurrentWave Prodigy is a versatile" +
					" electrical tomography instrument tailored for medical imaging and geological surveys."},
				new Equipment { EquipmentId = 5, Name = "ImpedanceMaster Plus", SurveyLineId = 5, Description = "The ImpedanceMaster Plus combines" +
					" impedance spectroscopy with tomographic imaging to deliver comprehensive electrical property maps." }
			);

		}
	}
}
