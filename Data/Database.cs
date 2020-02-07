using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Database : DbContext
    {
        public DbSet<Base> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Console.WriteLine($"PID: {Process.GetCurrentProcess().Id}");
            // System.Threading.Thread.Sleep(25000);

            optionsBuilder
                .UseSqlServer("fakeconnection")
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("customschema");

            modelBuilder.Entity<Base>();
            modelBuilder.Entity<Derived>().HasBaseType<Base>();

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Base
    {
        public int Id { get; set; }
    }

    public class Derived : Base
    {
        public string SomeDerivedStringProperty { get; set; }
    }
}
