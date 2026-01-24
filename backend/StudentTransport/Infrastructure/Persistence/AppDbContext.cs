using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<Route> Routes => Set<Route>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }
    }
}
