﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Models;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WebApp.Models.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrganizationEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(101);

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationEntityId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateOnly(1980, 1, 1),
                            Category = 0,
                            Created = new DateTime(2024, 11, 13, 11, 12, 13, 329, DateTimeKind.Local).AddTicks(3058),
                            Email = "john.doe@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            OrganizationId = 101,
                            phoneNumber = "123 123 321"
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateOnly(1980, 1, 1),
                            Category = 0,
                            Created = new DateTime(2024, 11, 13, 11, 12, 13, 329, DateTimeKind.Local).AddTicks(3105),
                            Email = "john.doe@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            OrganizationId = 101,
                            phoneNumber = "123 123 321"
                        });
                });

            modelBuilder.Entity("WebApp.Models.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("REGON")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 101,
                            NIP = "321312321",
                            Name = "Wsei",
                            REGON = "321312321"
                        },
                        new
                        {
                            Id = 102,
                            NIP = "232332323",
                            Name = "Firma",
                            REGON = "2342342423"
                        });
                });

            modelBuilder.Entity("WebApp.Models.ContactEntity", b =>
                {
                    b.HasOne("WebApp.Models.OrganizationEntity", null)
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationEntityId");
                });

            modelBuilder.Entity("WebApp.Models.OrganizationEntity", b =>
                {
                    b.OwnsOne("WebApp.Models.Adress", "Adress", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityId");

                            b1.ToTable("Organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityId = 101,
                                    City = "Kraków",
                                    Street = "Św.Filipa"
                                },
                                new
                                {
                                    OrganizationEntityId = 102,
                                    City = "Kraków",
                                    Street = "ŚW Igora"
                                });
                        });

                    b.Navigation("Adress")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.OrganizationEntity", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}