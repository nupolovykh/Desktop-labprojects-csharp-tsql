
namespace application_win_form_db.Models.EachEntityBuild
{
	internal static class OperatorsBuilder
	{
		public static void OperatorsBuild(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Operator>(entity =>
			{
				entity.HasIndex(e => e.SurveyLineId, "UQ__Operator__32CCE92072CBD4A9")
					.IsUnique();

				entity.HasIndex(e => e.UserId, "UQ__Operator__B9BE370E8A7607BB")
					.IsUnique();

				entity.Property(e => e.OperatorId)
					.ValueGeneratedNever()
					.HasColumnName("operator_id");

				entity.Property(e => e.FirstName)
					.HasMaxLength(100)
					.HasColumnName("first_name");

				entity.Property(e => e.LastName)
					.HasMaxLength(100)
					.HasColumnName("last_name");

				entity.Property(e => e.Phone)
					.HasMaxLength(100)
					.HasColumnName("phone");

				entity.Property(e => e.Surname)
					.HasMaxLength(100)
					.HasColumnName("surname");

				entity.Property(e => e.SurveyLineId).HasColumnName("survey_line_id");

				entity.Property(e => e.UserId).HasColumnName("user_id");

				entity.HasOne(d => d.SurveyLine)
					.WithOne(p => p.Operator)
					.HasForeignKey<Operator>(d => d.SurveyLineId)
					.HasConstraintName("fk_operator_surveyline");

				entity.HasOne(d => d.User)
					.WithOne(p => p.Operator)
					.HasForeignKey<Operator>(d => d.UserId)
					.HasConstraintName("FK_user_id");
			});

			modelBuilder.Entity<Operator>().HasData(
				new Operator { OperatorId = 1, FirstName = "John", LastName = "Doe", Phone = "123-456-7890",
					Surname = "Engineer", SurveyLineId = 1, UserId = 1 },
				new Operator { OperatorId = 2, FirstName = "Jane", LastName = "Smith", Phone = "987-654-3210",
					Surname = "Technician", SurveyLineId = 2, UserId = 2 },
				new Operator { OperatorId = 3, FirstName = "Michael", LastName = "Johnson", Phone = "555-123-4567",
					Surname = "Analyst", SurveyLineId = 3, UserId = 3 },
				new Operator { OperatorId = 4, FirstName = "Emily", LastName = "Brown", Phone = "555-987-6543",
					Surname = "Technician", SurveyLineId = 4, UserId = 4 }
			);

		}
	}
}
