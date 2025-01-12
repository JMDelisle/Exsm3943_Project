﻿// <auto-generated />
using System;
using ClassroomStart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassroomStart.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("ClassroomStart.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NameFirst")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Name(First)");

                    b.Property<string>("NameLast")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Name(Last)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.HasKey("Id");

                    b.ToTable("customer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "321 Elm Street",
                            NameFirst = "Phil",
                            NameLast = "Esposito",
                            PhoneNumber = "290-933-5657"
                        },
                        new
                        {
                            Id = 2,
                            Address = "20 Compton Way",
                            NameFirst = "Eric",
                            NameLast = "Clapton",
                            PhoneNumber = "644-379-6163"
                        },
                        new
                        {
                            Id = 3,
                            Address = "777 GTA V Street",
                            NameFirst = "Bill",
                            NameLast = "Murray",
                            PhoneNumber = "871-972-7144"
                        },
                        new
                        {
                            Id = 4,
                            Address = "11 White House",
                            NameFirst = "Nancy",
                            NameLast = "Peluso",
                            PhoneNumber = "672-359-1685"
                        },
                        new
                        {
                            Id = 5,
                            Address = "99 Beachwood Lane",
                            NameFirst = "Sandy",
                            NameLast = "Seashore",
                            PhoneNumber = "331-423-0749"
                        },
                        new
                        {
                            Id = 6,
                            Address = "560 Hellsgate Inn",
                            NameFirst = "Sara",
                            NameLast = "Bigwood",
                            PhoneNumber = "976-832-8846"
                        },
                        new
                        {
                            Id = 7,
                            Address = "411 Eagle Street",
                            NameFirst = "Peter",
                            NameLast = "Gabriel",
                            PhoneNumber = "407-321-1120"
                        },
                        new
                        {
                            Id = 8,
                            Address = "100 Acre Woods",
                            NameFirst = "Winnie",
                            NameLast = "DaPooh",
                            PhoneNumber = "703-814-7093"
                        },
                        new
                        {
                            Id = 9,
                            Address = "99 Peanuts Avenue",
                            NameFirst = "Charlie",
                            NameLast = "Brown",
                            PhoneNumber = "565-734-5713"
                        },
                        new
                        {
                            Id = 10,
                            Address = "#2 Air Tonite Way",
                            NameFirst = "Phil",
                            NameLast = "Collins",
                            PhoneNumber = "490-817-3191"
                        });
                });

            modelBuilder.Entity("ClassroomStart.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<decimal>("Cost")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Minimum")
                        .HasColumnType("int(11)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int(11)")
                        .HasColumnName("Product Category ID");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Product Name");

                    b.Property<int>("QuantityOnHand")
                        .HasColumnType("int(11)")
                        .HasColumnName("Quantity On Hand");

                    b.Property<decimal>("SalePrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProductCategoryId" }, "Product Category ID");

                    b.ToTable("products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 225.00m,
                            Minimum = 4,
                            ProductCategoryId = 1,
                            ProductName = "White Toner",
                            QuantityOnHand = 6,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 2,
                            Cost = 200.00m,
                            Minimum = 4,
                            ProductCategoryId = 1,
                            ProductName = "Black Toner",
                            QuantityOnHand = 3,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 3,
                            Cost = 600.00m,
                            Minimum = 4,
                            ProductCategoryId = 1,
                            ProductName = "Red Toner",
                            QuantityOnHand = 5,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 4,
                            Cost = 500.00m,
                            Minimum = 4,
                            ProductCategoryId = 1,
                            ProductName = "Orange Toner",
                            QuantityOnHand = 5,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 5,
                            Cost = 550.00m,
                            Minimum = 3,
                            ProductCategoryId = 1,
                            ProductName = "Yellow Toner",
                            QuantityOnHand = 2,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 6,
                            Cost = 325.00m,
                            Minimum = 4,
                            ProductCategoryId = 1,
                            ProductName = "Green Toner",
                            QuantityOnHand = 4,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 7,
                            Cost = 420.00m,
                            Minimum = 4,
                            ProductCategoryId = 1,
                            ProductName = "Blue Toner",
                            QuantityOnHand = 4,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 8,
                            Cost = 575.00m,
                            Minimum = 4,
                            ProductCategoryId = 1,
                            ProductName = "Indigo Toner",
                            QuantityOnHand = 4,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 9,
                            Cost = 750.00m,
                            Minimum = 4,
                            ProductCategoryId = 1,
                            ProductName = "Violet Toner",
                            QuantityOnHand = 2,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 10,
                            Cost = 65.00m,
                            Minimum = 6,
                            ProductCategoryId = 1,
                            ProductName = "Gun Wash",
                            QuantityOnHand = 10,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 11,
                            Cost = 75.00m,
                            Minimum = 5,
                            ProductCategoryId = 2,
                            ProductName = "180 Grit Sandpaper",
                            QuantityOnHand = 8,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 12,
                            Cost = 75.00m,
                            Minimum = 5,
                            ProductCategoryId = 2,
                            ProductName = "220 Grit Sandpaper",
                            QuantityOnHand = 9,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 13,
                            Cost = 85.00m,
                            Minimum = 5,
                            ProductCategoryId = 2,
                            ProductName = "320 Grit Sandpaper",
                            QuantityOnHand = 6,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 14,
                            Cost = 85.00m,
                            Minimum = 5,
                            ProductCategoryId = 2,
                            ProductName = "400 Grit Sandpaper",
                            QuantityOnHand = 6,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 15,
                            Cost = 85.00m,
                            Minimum = 5,
                            ProductCategoryId = 2,
                            ProductName = "600 Grit Sandpaper",
                            QuantityOnHand = 3,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 16,
                            Cost = 85.00m,
                            Minimum = 5,
                            ProductCategoryId = 2,
                            ProductName = "800 Grit Sandpaper",
                            QuantityOnHand = 6,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 17,
                            Cost = 55.00m,
                            Minimum = 5,
                            ProductCategoryId = 2,
                            ProductName = "1500 Grit Sandpaper",
                            QuantityOnHand = 6,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 18,
                            Cost = 35.00m,
                            Minimum = 5,
                            ProductCategoryId = 3,
                            ProductName = "Bronze Bondo",
                            QuantityOnHand = 6,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 19,
                            Cost = 45.00m,
                            Minimum = 5,
                            ProductCategoryId = 3,
                            ProductName = "Silver Bondo",
                            QuantityOnHand = 4,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 20,
                            Cost = 65.00m,
                            Minimum = 5,
                            ProductCategoryId = 3,
                            ProductName = "Gold Bondo",
                            QuantityOnHand = 1,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 21,
                            Cost = 30.00m,
                            Minimum = 5,
                            ProductCategoryId = 3,
                            ProductName = "Finishing Putty",
                            QuantityOnHand = 4,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 22,
                            Cost = 45.00m,
                            Minimum = 10,
                            ProductCategoryId = 4,
                            ProductName = "Coveralls",
                            QuantityOnHand = 4,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 23,
                            Cost = 45.00m,
                            Minimum = 6,
                            ProductCategoryId = 4,
                            ProductName = "Respirator",
                            QuantityOnHand = 4,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 24,
                            Cost = 30.00m,
                            Minimum = 65,
                            ProductCategoryId = 4,
                            ProductName = "Gloves",
                            QuantityOnHand = 15,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 25,
                            Cost = 10.00m,
                            Minimum = 65,
                            ProductCategoryId = 5,
                            ProductName = "Rags",
                            QuantityOnHand = 15,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 26,
                            Cost = 5.00m,
                            Minimum = 65,
                            ProductCategoryId = 5,
                            ProductName = "Razor Blades",
                            QuantityOnHand = 75,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 27,
                            Cost = 40.00m,
                            Minimum = 10,
                            ProductCategoryId = 5,
                            ProductName = "Masking Paper",
                            QuantityOnHand = 15,
                            SalePrice = 0m
                        },
                        new
                        {
                            Id = 28,
                            Cost = 6.00m,
                            Minimum = 65,
                            ProductCategoryId = 5,
                            ProductName = "Masking Tape",
                            QuantityOnHand = 155,
                            SalePrice = 0m
                        });
                });

            modelBuilder.Entity("ClassroomStart.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Category Name");

                    b.HasKey("Id");

                    b.ToTable("product category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Paint"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "SandPaper"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Filler"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "PPE"
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Shop Supplies"
                        });
                });

            modelBuilder.Entity("ClassroomStart.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int(11)")
                        .HasColumnName("Customer ID");

                    b.Property<decimal>("ExtendedPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Extended Price");

                    b.Property<decimal>("IndividualPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Individual Price");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int(11)")
                        .HasColumnName("Product Category ID");

                    b.Property<int>("ProductNameId")
                        .HasColumnType("int(11)")
                        .HasColumnName("Product Name ID");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("int(11)")
                        .HasColumnName("Quantity Ordered");

                    b.Property<DateTime>("TimeDateOfOrder")
                        .HasColumnType("datetime")
                        .HasColumnName("Time/Date of Order");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Total Price");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CustomerId" }, "Customer ID");

                    b.HasIndex(new[] { "ProductCategoryId" }, "Product Category ID1");

                    b.HasIndex(new[] { "ProductNameId" }, "Product Name ID");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("ClassroomStart.Models.Product", b =>
                {
                    b.HasOne("ClassroomStart.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .IsRequired()
                        .HasConstraintName("products_ibfk_1");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ClassroomStart.Models.Transaction", b =>
                {
                    b.HasOne("ClassroomStart.Models.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("transactions_ibfk_1");

                    b.HasOne("ClassroomStart.Models.ProductCategory", "ProductCategory")
                        .WithMany("Transactions")
                        .HasForeignKey("ProductCategoryId")
                        .IsRequired()
                        .HasConstraintName("transactions_ibfk_2");

                    b.HasOne("ClassroomStart.Models.Product", "ProductName")
                        .WithMany("Transactions")
                        .HasForeignKey("ProductNameId")
                        .IsRequired()
                        .HasConstraintName("transactions_ibfk_3");

                    b.Navigation("Customer");

                    b.Navigation("ProductCategory");

                    b.Navigation("ProductName");
                });

            modelBuilder.Entity("ClassroomStart.Models.Customer", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ClassroomStart.Models.Product", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ClassroomStart.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
