﻿// <auto-generated />
using System;
using ClassroomStart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassroomStart.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220816010851_test_migration_1")]
    partial class test_migration_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("customer");
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

                    b.ToTable("products");

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

                    b.ToTable("product category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Paint"
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

                    b.ToTable("transactions");
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
