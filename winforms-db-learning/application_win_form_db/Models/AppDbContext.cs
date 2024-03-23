
using application_win_form_db.Services;

namespace application_win_form_db.Models
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();

			DatabaseInspector inspector = new(this);
			inspector.InspectDatabase();
		}

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)	{}

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
                //home data source
                optionsBuilder.UseSqlServer("Server=.\\;Database=107g2_PolovykhNA2;Trusted_Connection=True;TrustServerCertificate=true;");

                //college data source
                //optionsBuilder.UseSqlServer("Server=DBSRV\\AG2022;Initial Catalog=107g2_PolovykhNA2;Integrated Security=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.CustomerBuild();
			modelBuilder.DatumBuild();
			modelBuilder.EquipmentBuild();
			modelBuilder.MeasurementsBuild();
			modelBuilder.OperatorsBuild();
			modelBuilder.PicketsBuild();
			modelBuilder.ProjectBuild();
			modelBuilder.TerrainBuild();
			modelBuilder.SurveyiLinesBuild();
			modelBuilder.UsersBuild();

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
