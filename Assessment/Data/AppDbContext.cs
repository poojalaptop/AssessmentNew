using Assessment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Assessment.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(u => u.Name).HasMaxLength(50).IsRequired();
                entity.Property(u => u.Symbol).HasMaxLength(10).IsRequired();
                entity.HasIndex(u => u.Symbol).IsUnique();

                entity.HasOne(u => u.Category)
                      .WithMany(c => c.Units)
                      .HasForeignKey(u => u.CategoryId);
            });

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Length" },
                new Category { Id = 2, Name = "Weight" },
                new Category { Id = 3, Name = "Temperature" },
                new Category { Id = 4, Name = "Volume" }
            );

            modelBuilder.Entity<Unit>().HasData(
           
                new Unit { Id = 1, Name = "Meter", Symbol = "m", Factor = 1, Offset = 0, CategoryId = 1 },
                new Unit { Id = 2, Name = "Kilometer", Symbol = "km", Factor = 1000, Offset = 0, CategoryId = 1 },
                new Unit { Id = 3, Name = "Centimeter", Symbol = "cm", Factor = 0.01, Offset = 0, CategoryId = 1 },
                new Unit { Id = 4, Name = "Millimeter", Symbol = "mm", Factor = 0.001, Offset = 0, CategoryId = 1 },
                new Unit { Id = 5, Name = "Mile", Symbol = "mi", Factor = 1609.344, Offset = 0, CategoryId = 1 },
                new Unit { Id = 6, Name = "Yard", Symbol = "yd", Factor = 0.9144, Offset = 0, CategoryId = 1 },
                new Unit { Id = 7, Name = "Foot", Symbol = "ft", Factor = 0.3048, Offset = 0, CategoryId = 1 },
                new Unit { Id = 8, Name = "Inch", Symbol = "in", Factor = 0.0254, Offset = 0, CategoryId = 1 },

                new Unit { Id = 9, Name = "Kilogram", Symbol = "kg", Factor = 1, Offset = 0, CategoryId = 2 },
                new Unit { Id = 10, Name = "Gram", Symbol = "g", Factor = 0.001, Offset = 0, CategoryId = 2 },
                new Unit { Id = 11, Name = "Milligram", Symbol = "mg", Factor = 0.000001, Offset = 0, CategoryId = 2 },
                new Unit { Id = 12, Name = "Tonne", Symbol = "t", Factor = 1000, Offset = 0, CategoryId = 2 },
                new Unit { Id = 13, Name = "Pound", Symbol = "lb", Factor = 0.45359237, Offset = 0, CategoryId = 2 },
                new Unit { Id = 14, Name = "Ounce", Symbol = "oz", Factor = 0.028349523125, Offset = 0, CategoryId = 2 },

             
                new Unit { Id = 15, Name = "Kelvin", Symbol = "K", Factor = 1, Offset = 0, CategoryId = 3 },
                new Unit { Id = 16, Name = "Celsius", Symbol = "C", Factor = 1, Offset = 273.15, CategoryId = 3 },
                new Unit { Id = 17, Name = "Fahrenheit", Symbol = "F", Factor = 5.0 / 9.0, Offset = 459.67, CategoryId = 3 },

     
                new Unit { Id = 18, Name = "Liter", Symbol = "L", Factor = 1, Offset = 0, CategoryId = 4 },
                new Unit { Id = 19, Name = "Milliliter", Symbol = "mL", Factor = 0.001, Offset = 0, CategoryId = 4 },
                new Unit { Id = 20, Name = "Cubic meter", Symbol = "m3", Factor = 1000, Offset = 0, CategoryId = 4 },
                new Unit { Id = 21, Name = "US Gallon", Symbol = "gal", Factor = 3.785411784, Offset = 0, CategoryId = 4 }
            );
        }
    }
}
