﻿// <auto-generated />
using Koton.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Koton.Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20220111172523_Catalog")]
    partial class Catalog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Koton.Catalog.Infrastructure.Core.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brand1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Brand2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Brand3"
                        });
                });

            modelBuilder.Entity("Koton.Catalog.Infrastructure.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Category"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Category2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Category3"
                        });
                });

            modelBuilder.Entity("Koton.Catalog.Infrastructure.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("StockCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CategoryId = 1,
                            Name = "Product1",
                            Price = 50m,
                            StockCode = "1234ERT",
                            StockQuantity = 500,
                            Unit = "adet"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CategoryId = 1,
                            Name = "Product2",
                            Price = 125m,
                            StockCode = "1234WQT",
                            StockQuantity = 100,
                            Unit = "adet"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            CategoryId = 3,
                            Name = "Product3",
                            Price = 12m,
                            StockCode = "122323RT",
                            StockQuantity = 25,
                            Unit = "adet"
                        });
                });

            modelBuilder.Entity("Koton.Catalog.Infrastructure.Core.Entities.Product", b =>
                {
                    b.HasOne("Koton.Catalog.Infrastructure.Core.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Koton.Catalog.Infrastructure.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Koton.Catalog.Infrastructure.Core.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Koton.Catalog.Infrastructure.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
