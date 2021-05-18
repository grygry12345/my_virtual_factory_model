﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using model_test.Data;

namespace model_test.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20210518171036_Test12")]
    partial class Test12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("model_test.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("model_test.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("model_test.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("model_test.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("model_test.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsSalable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("model_test.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("End")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Start")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkCenterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WorkCenterId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("model_test.Models.SubProductTree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subproduct")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("SubProductTrees");
                });

            modelBuilder.Entity("model_test.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("model_test.Models.WorkCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WorkCenters");
                });

            modelBuilder.Entity("model_test.Models.WorkCenterOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OperationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Speed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkCenterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OperationId")
                        .IsUnique();

                    b.HasIndex("WorkCenterId");

                    b.ToTable("WorkCenterOperations");
                });

            modelBuilder.Entity("model_test.Models.Order", b =>
                {
                    b.HasOne("model_test.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("model_test.Models.OrderItem", b =>
                {
                    b.HasOne("model_test.Models.Order", "Order")
                        .WithMany("OrderItem")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("model_test.Models.Product", "Product")
                        .WithMany("OrderItem")
                        .HasForeignKey("ProductId");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("model_test.Models.Schedule", b =>
                {
                    b.HasOne("model_test.Models.Product", "Product")
                        .WithMany("Schedule")
                        .HasForeignKey("ProductId");

                    b.HasOne("model_test.Models.WorkCenter", "WorkCenter")
                        .WithMany("Schedule")
                        .HasForeignKey("WorkCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("WorkCenter");
                });

            modelBuilder.Entity("model_test.Models.SubProductTree", b =>
                {
                    b.HasOne("model_test.Models.Product", "Product")
                        .WithMany("SubProductTree")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("model_test.Models.WorkCenterOperation", b =>
                {
                    b.HasOne("model_test.Models.Operation", "Operation")
                        .WithOne("WorkCenterOperation")
                        .HasForeignKey("model_test.Models.WorkCenterOperation", "OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("model_test.Models.WorkCenter", "WorkCenter")
                        .WithMany("WorkCenterOperation")
                        .HasForeignKey("WorkCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");

                    b.Navigation("WorkCenter");
                });

            modelBuilder.Entity("model_test.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("model_test.Models.Operation", b =>
                {
                    b.Navigation("WorkCenterOperation");
                });

            modelBuilder.Entity("model_test.Models.Order", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("model_test.Models.Product", b =>
                {
                    b.Navigation("OrderItem");

                    b.Navigation("Schedule");

                    b.Navigation("SubProductTree");
                });

            modelBuilder.Entity("model_test.Models.WorkCenter", b =>
                {
                    b.Navigation("Schedule");

                    b.Navigation("WorkCenterOperation");
                });
#pragma warning restore 612, 618
        }
    }
}
