using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClassroomStart.Models;

namespace ClassroomStart.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;database=bits_&_bytes", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            //Seed Data Goes Here

            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                Id = 1,
                CategoryName = "Paint"
            });

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ProductCategoryId = 1,
                ProductName = "White Toner",
                QuantityOnHand = 6,
                Minimum = 4,
                Cost = 225.00m,

            },
                new Product()
                {
                    Id = 2,
                    ProductCategoryId = 1,
                    ProductName = "Black Toner",
                    QuantityOnHand = 3,
                    Minimum = 4,
                    Cost = 200.00m,
                },
                new Product()
                {
                    Id = 3,
                    ProductCategoryId = 1,
                    ProductName = "Red Toner",
                    QuantityOnHand = 5,
                    Minimum = 4,
                    Cost = 600.00m,
                },
                new Product()
                {
                    Id = 4,
                    ProductCategoryId = 1,
                    ProductName = "Orange Toner",
                    QuantityOnHand = 5,
                    Minimum = 4,
                    Cost = 500.00m,
                }
        );

            modelBuilder.Entity<Customer>().HasData(new Customer()
            {
                Id = 1,
                NameFirst = "Phil",
                NameLast = "Esposito",
                PhoneNumber = "333-555-6767",
                Address = "321 Elm Street"
            },

             new Customer()
             {
                 Id = 2,
                 NameFirst = "Eric",
                 NameLast = "Clapton",
                 PhoneNumber = "676-444-1234",
                 Address = "20 Compton Way"




             });

                   


            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_1");
    });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transactions_ibfk_1");

    entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transactions_ibfk_2");

    entity.HasOne(d => d.ProductName)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ProductNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transactions_ibfk_3");
});






OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
