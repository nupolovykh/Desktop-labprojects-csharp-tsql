using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeFirstExistingDatabaseSample.Models
{
	public partial class temptForConsoleContext : DbContext
	{
		public temptForConsoleContext()
		{
		}

		public temptForConsoleContext(DbContextOptions<temptForConsoleContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Blog> Blogs { get; set; } = null!;
		public virtual DbSet<Post> Posts { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.\\;Database=temptForConsole;Trusted_Connection=True;TrustServerCertificate=true;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Blog>(entity =>
			{
				entity.Property(e => e.Name).HasMaxLength(200);

				entity.Property(e => e.Url).HasMaxLength(200);
			});

			modelBuilder.Entity<Post>(entity =>
			{
				entity.Property(e => e.Content).HasColumnType("ntext");

				entity.Property(e => e.Title).HasMaxLength(200);

				entity.HasOne(d => d.Blog)
					.WithMany(p => p.Posts)
					.HasForeignKey(d => d.BlogId)
					.HasConstraintName("FK_dbo.Posts_dbo.Blogs_BlogId");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
