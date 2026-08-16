using Lab7.Models.Database.Entity;
using Lab7.Services;
using Lab7.Services.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab7.Models.Database
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) :base(options) 
		{
            //Database.EnsureDeleted();
            Database.EnsureCreated();
		}

		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Role> Roles { get; set; } = null!;
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
			optionsBuilder.LogTo(s => Trace.WriteLine(s));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Role>().HasData(
			   new Role { Id = 1, Name = "Admin" },
			   new Role { Id = 2, Name = "Employee" });

			modelBuilder.Entity<User>().HasData(
				new User { Id = 1, RoleId = 1, Login = "NikitaSuperCool", Password = "123".Hash_MD5() },
				new User { Id = 2, RoleId = 2, Login = "SeniorDonkey", Password = "lolol".Hash_MD5() },
				new User { Id = 3, RoleId = 2, Login = "LenaPoleno", Password = "sapogi".Hash_MD5() });

		}
	}
}
