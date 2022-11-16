﻿// <auto-generated />
using System;
using FridgeWarehouse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FridgeWarehouse.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221116182445_addLocationAddress")]
    partial class addLocationAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FridgeWarehouse.Data.Entities.Fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FridgeModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FridgeModelId")
                        .IsUnique();

                    b.ToTable("Fridges");
                });

            modelBuilder.Entity("FridgeWarehouse.Data.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FridsgeWarehouse.Data.Entities.FridgeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FridgeModels");
                });

            modelBuilder.Entity("FridsgeWarehouse.Data.Entities.FridgeProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("FridgeProduct");
                });

            modelBuilder.Entity("FridgeWarehouse.Data.Entities.Fridge", b =>
                {
                    b.HasOne("FridsgeWarehouse.Data.Entities.FridgeModel", "FridgeModel")
                        .WithOne("Fridge")
                        .HasForeignKey("FridgeWarehouse.Data.Entities.Fridge", "FridgeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FridgeModel");
                });

            modelBuilder.Entity("FridsgeWarehouse.Data.Entities.FridgeProduct", b =>
                {
                    b.HasOne("FridgeWarehouse.Data.Entities.Fridge", "Fridge")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FridgeWarehouse.Data.Entities.Product", "Product")
                        .WithOne("FridgeProduct")
                        .HasForeignKey("FridsgeWarehouse.Data.Entities.FridgeProduct", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FridgeWarehouse.Data.Entities.Fridge", b =>
                {
                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("FridgeWarehouse.Data.Entities.Product", b =>
                {
                    b.Navigation("FridgeProduct")
                        .IsRequired();
                });

            modelBuilder.Entity("FridsgeWarehouse.Data.Entities.FridgeModel", b =>
                {
                    b.Navigation("Fridge")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
