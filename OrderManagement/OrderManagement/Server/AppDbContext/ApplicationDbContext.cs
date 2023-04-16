using OrderManagement.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace OrderManagement.Server.AppDbContext
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<Subelement> Subelements { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(e => e.Windows)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Window>()
                .HasMany(e => e.Subelements)
                .WithOne(e => e.Window)
                .HasForeignKey(e => e.WindowId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subelement>()
                .HasKey(e => e.Id);

            #region Seed

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Name = "New York Building 1", State = "NY" });
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 2, Name = "California Hotel AJK", State = "CA" });

            modelBuilder.Entity<Window>().HasData(
                new Window { Id = 1, OrderId = 1, Name = "A51", Quantity = 4 });
            modelBuilder.Entity<Window>().HasData(
                new Window { Id = 2, OrderId = 1, Name = "C Zone 5", Quantity = 2 });
            modelBuilder.Entity<Window>().HasData(
                new Window { Id = 3, OrderId = 2, Name = "GLB", Quantity = 3 });
            modelBuilder.Entity<Window>().HasData(
                new Window { Id = 4, OrderId = 2, Name = "OHF", Quantity = 10 });

            modelBuilder.Entity<Subelement>().HasData(
                new Subelement { Id = 1, WindowId = 1, Type = "Doors", Width = 1200, Height = 1850 });
            modelBuilder.Entity<Subelement>().HasData(
                new Subelement { Id = 2, WindowId = 1, Type = "Window", Width = 800, Height = 1850 });
            modelBuilder.Entity<Subelement>().HasData(
                new Subelement { Id = 3, WindowId = 1, Type = "Window", Width = 700, Height = 1850 });

            modelBuilder.Entity<Subelement>().HasData(
                new Subelement { Id = 4, WindowId = 2, Type = "Window", Width = 1500, Height = 2000 });

            modelBuilder.Entity<Subelement>().HasData(
                new Subelement { Id = 5, WindowId = 3, Type = "Doors", Width = 1400, Height = 2200 });
            modelBuilder.Entity<Subelement>().HasData(
                new Subelement { Id = 6, WindowId = 3, Type = "Window", Width = 600, Height = 2200 });


            modelBuilder.Entity<Subelement>().HasData(
                new Subelement { Id = 7, WindowId = 4, Type = "Window", Width = 1500, Height = 2000 });
            modelBuilder.Entity<Subelement>().HasData(
                new Subelement { Id = 8, WindowId = 4, Type = "Window", Width = 1500, Height = 2000 });

            #endregion
        }
    }
}
