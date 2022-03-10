﻿// <auto-generated />
using System;
using GoEat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoEat.Infrastructure.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20220301213145_AddedSeedData")]
    partial class AddedSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GoEat.Logic.Order.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Order", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b61cfc10-90ee-46ae-b1a2-78e3c529cd7e")
                        });
                });

            modelBuilder.Entity("GoEat.Logic.Order.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ItemQuantity")
                        .HasColumnType("int");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1c1ffcf-1427-4672-8272-1c8a6e575a37"),
                            ItemQuantity = 1,
                            OrderId = new Guid("b61cfc10-90ee-46ae-b1a2-78e3c529cd7e"),
                            Price = 0.00m
                        });
                });

            modelBuilder.Entity("GoEat.Logic.Order.OrderItem", b =>
                {
                    b.HasOne("GoEat.Logic.Order.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("GoEat.Logic.Order.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
