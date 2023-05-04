﻿// <auto-generated />
using System;
using Consimple.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Consimple.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230504091610_InitCreate")]
    partial class InitCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Consimple.Database.Entities.CategoryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Consimple.Database.Entities.CheckEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ClientFK")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClientFK");

                    b.ToTable("Checks", (string)null);
                });

            modelBuilder.Entity("Consimple.Database.Entities.ClientEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.Property<DateTime?>("ModiliedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Consimple.Database.Entities.ProductCategoryEntity", b =>
                {
                    b.Property<long>("CategoryFK")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductFK")
                        .HasColumnType("bigint");

                    b.HasKey("CategoryFK", "ProductFK");

                    b.HasIndex("ProductFK");

                    b.ToTable("ProductCategories", (string)null);
                });

            modelBuilder.Entity("Consimple.Database.Entities.ProductEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CheckFK")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModiliedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.HasKey("Id");

                    b.HasIndex("CheckFK");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Consimple.Database.Entities.CheckEntity", b =>
                {
                    b.HasOne("Consimple.Database.Entities.ClientEntity", "Client")
                        .WithMany("Checks")
                        .HasForeignKey("ClientFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Consimple.Database.Entities.ProductCategoryEntity", b =>
                {
                    b.HasOne("Consimple.Database.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Consimple.Database.Entities.ProductEntity", "Product")
                        .WithMany("Categories")
                        .HasForeignKey("ProductFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Consimple.Database.Entities.ProductEntity", b =>
                {
                    b.HasOne("Consimple.Database.Entities.CheckEntity", "Check")
                        .WithMany("Products")
                        .HasForeignKey("CheckFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Check");
                });

            modelBuilder.Entity("Consimple.Database.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Consimple.Database.Entities.CheckEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Consimple.Database.Entities.ClientEntity", b =>
                {
                    b.Navigation("Checks");
                });

            modelBuilder.Entity("Consimple.Database.Entities.ProductEntity", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
