using System;
using Microsoft.EntityFrameworkCore;
using SneakerCollection.Domain.User;
using SneakerCollection.Domain.UserAggregate.Entities;

namespace SneakerCollection.Infrastructure.Persistence
{
	public class SneakerDbContext : DbContext
	{
		public SneakerDbContext(DbContextOptions<SneakerDbContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Sneaker> Sneakers { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(SneakerDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}
    }
}

