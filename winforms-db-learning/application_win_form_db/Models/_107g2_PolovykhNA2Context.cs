using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace application_win_form_db.Models
{
	public partial class _107g2_PolovykhNA2Context : DbContext
	{
		public _107g2_PolovykhNA2Context()
		{
		}

		public _107g2_PolovykhNA2Context(DbContextOptions<_107g2_PolovykhNA2Context> options) : base(options)	{}

		public virtual DbSet<Customer> Customers { get; set; } = null!;
		public virtual DbSet<Datum> Data { get; set; } = null!;
		public virtual DbSet<Equipment> Equipment { get; set; } = null!;
		public virtual DbSet<Measurement> Measurements { get; set; } = null!;
		public virtual DbSet<Operator> Operators { get; set; } = null!;
		public virtual DbSet<Picket> Pickets { get; set; } = null!;
		public virtual DbSet<Project> Projects { get; set; } = null!;
		public virtual DbSet<SurveyLine> SurveyLines { get; set; } = null!;
		public virtual DbSet<Terrain> Terrains { get; set; } = null!;
		public virtual DbSet<User> Users { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.\\;Database=107g2_PolovykhNA2;Trusted_Connection=True;TrustServerCertificate=true;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>(entity =>
			{
				entity.Property(e => e.CustomerId)
					.ValueGeneratedNever()
					.HasColumnName("customer_id ");

				entity.Property(e => e.Address)
					.HasMaxLength(100)
					.HasColumnName("address");

				entity.Property(e => e.City)
					.HasMaxLength(100)
					.HasColumnName("city");

				entity.Property(e => e.Name)
					.HasMaxLength(100)
					.HasColumnName("name");

				entity.Property(e => e.Phone)
					.HasMaxLength(100)
					.HasColumnName("phone");
			});

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

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
