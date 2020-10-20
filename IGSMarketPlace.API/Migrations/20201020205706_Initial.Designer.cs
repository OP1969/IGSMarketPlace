﻿// <auto-generated />
using IGSMarketPlace.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IGSMarketPlace.API.Migrations
{
    [DbContext(typeof(IGSContext))]
    [Migration("20201020205706_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("IGSMarketPlace.API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lavender heart",
                            Price = "9.25"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Personalised cufflinks",
                            Price = "45.00"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kids T-shirt",
                            Price = "19.95"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
