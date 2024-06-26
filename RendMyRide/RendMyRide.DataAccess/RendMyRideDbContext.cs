﻿using Microsoft.EntityFrameworkCore;
using RendMyRide.Domain.Models;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace RendMyRide.DataAccess
{
    public class RendMyRideDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        public RendMyRideDbContext(DbContextOptions<RendMyRideDbContext> options)
            :base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
