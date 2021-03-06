﻿// <auto-generated />
using System;
using Infotech.TestTask.Webapi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infotech.TestTask.Webapi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200827205011_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Infotech.TestTask.Webapi.Models.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<string>("Maker")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<string>("NationalId")
                        .HasColumnType("TEXT");

                    b.Property<string>("VIN")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("YearOfManufacture")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Infotech.TestTask.Webapi.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExternalId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Infotech.TestTask.Webapi.Models.PersonCar", b =>
                {
                    b.Property<long>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CarId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PersonId", "CarId");

                    b.HasIndex("CarId");

                    b.ToTable("PersonCars");
                });

            modelBuilder.Entity("Infotech.TestTask.Webapi.Models.PersonCar", b =>
                {
                    b.HasOne("Infotech.TestTask.Webapi.Models.Car", "Car")
                        .WithMany("PersonCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infotech.TestTask.Webapi.Models.Person", "Person")
                        .WithMany("PersonCars")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
