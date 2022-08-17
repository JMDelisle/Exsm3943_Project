using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClassroomStart.Models;

namespace ClassroomStart.Models
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
            },
            new ProductCategory()
            {
                Id = 2,
                CategoryName = "SandPaper"
            },
            new ProductCategory()
            {
                Id = 3,
                CategoryName = "Filler"
            },
            new ProductCategory()
            {
                Id=4,
                CategoryName = "PPE"
            },
            new ProductCategory()
            {
                Id=5,
                CategoryName = "Shop Supplies"
            }
            );

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ProductCategoryId = 1,
                ProductName = "White Toner",
                QuantityOnHand = 6,
                Minimum = 4,
                Cost = 225.00m

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
                PhoneNumber = "290-933-5657",
                Address = "321 Elm Street"
            },

             new Customer()
             {
                 Id = 2,
                 NameFirst = "Eric",
                 NameLast = "Clapton",
                 PhoneNumber = "644-379-6163",
                 Address = "20 Compton Way"
             },
             new Customer()
             {
                 Id = 3,
                 NameFirst = "Bill",
                 NameLast = "Murray",
                 PhoneNumber = "871-972-7144",
                 Address = "777 GTA V Street"
              },

              new Customer()
              {
                  Id = 4,
                  NameFirst = "Nancy",
                  NameLast = "Peluso",
                  PhoneNumber = "672-359-1685",
                  Address = "11 White House"
              },

               new Customer()
               {
                   Id = 5,
                   NameFirst = "Sandy",
                   NameLast = "Seashore",
                   PhoneNumber = "331-423-0749",
                   Address = "99 Beachwood Lane"

               },

               new Customer()
               {
                   Id = 6,
                   NameFirst = "Sara",
                   NameLast = "Bigwood",
                   PhoneNumber = "976-832-8846",
                   Address = "560 Hellsgate Inn"
               },
                new Customer()
                {
                    Id = 7,
                    NameFirst = "Peter",
                    NameLast = "Gabriel",
                    PhoneNumber = "407-321-1120",
                    Address = "411 Eagle Street"
                },
                new Customer()
                {
                    Id = 8,
                    NameFirst = "Winnie",
                    NameLast = "DaPooh",
                    PhoneNumber = "703-814-7093",
                    Address = "100 Acre Woods"
                },
                new Customer()
                {
                    Id = 9,
                    NameFirst = "Charlie",
                    NameLast = "Brown",
                    PhoneNumber = "565-734-5713",
                    Address = "99 Peanuts Avenue"
                },
                 new Customer()
                 {
                     Id = 10,
                     NameFirst = "Phil",
                     NameLast = "Collins",
                     PhoneNumber = "490-817-3191",
                     Address = "#2 Air Tonite Way"
                 
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
