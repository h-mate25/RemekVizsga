﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    partial class WarehouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Entities.Pallet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("isOrdered")
                        .HasColumnType("bit");

                    b.Property<int>("place_id")
                        .HasColumnType("int");

                    b.Property<int>("qrcode")
                        .HasColumnType("int");

                    b.Property<double>("weight")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Pallet");
                });

            modelBuilder.Entity("Model.Entities.Pallets", b =>
                {
                    b.Property<int>("process_id")
                        .HasColumnType("int");

                    b.Property<int>("pallet_id")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("process_id", "pallet_id");

                    b.HasIndex("pallet_id");

                    b.ToTable("Pallets");
                });

            modelBuilder.Entity("Model.Entities.Process", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("incomingCargo_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("outgoingCargo_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("worker_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("Model.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("barcode")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("onPallet")
                        .HasColumnType("bit");

                    b.Property<int>("pallet_id")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("weight")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("pallet_id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Model.Entities.Products", b =>
                {
                    b.Property<int>("process_id")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("process_id", "product_id");

                    b.HasIndex("product_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Model.Entities.Pallets", b =>
                {
                    b.HasOne("Model.Entities.Pallet", "pallet")
                        .WithMany("Pallets")
                        .HasForeignKey("pallet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Process", "Process")
                        .WithMany("Pallets")
                        .HasForeignKey("process_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");

                    b.Navigation("pallet");
                });

            modelBuilder.Entity("Model.Entities.Product", b =>
                {
                    b.HasOne("Model.Entities.Pallet", "pallet")
                        .WithMany("Product")
                        .HasForeignKey("pallet_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pallet");
                });

            modelBuilder.Entity("Model.Entities.Products", b =>
                {
                    b.HasOne("Model.Entities.Process", "Process")
                        .WithMany("Products")
                        .HasForeignKey("process_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Product", "Product")
                        .WithMany("Products")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Model.Entities.Pallet", b =>
                {
                    b.Navigation("Pallets");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Model.Entities.Process", b =>
                {
                    b.Navigation("Pallets");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Model.Entities.Product", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
