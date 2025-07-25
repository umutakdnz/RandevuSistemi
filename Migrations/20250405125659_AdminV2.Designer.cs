﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RandevuSistemi.Models.AdminSiniflar;

#nullable disable

namespace RandevuSistemi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250405125659_AdminV2")]
    partial class AdminV2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoundedYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Person")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Barber", b =>
                {
                    b.Property<int>("BarberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BarberId"));

                    b.Property<string>("BarberDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BarberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BarberNumber")
                        .HasColumnType("int");

                    b.Property<string>("Expertise")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BarberId");

                    b.ToTable("Barbers");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Campaigns", b =>
                {
                    b.Property<int>("CampaignsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignsId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignsId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Comments", b =>
                {
                    b.Property<int>("CommentsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentsID"));

                    b.Property<string>("COmmentsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentsID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.HomePage", b =>
                {
                    b.Property<int>("HomePageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HomePageID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HomePageID");

                    b.ToTable("HomePages");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Messages", b =>
                {
                    b.Property<int>("MessagesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessagesID"));

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessagesID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Price", b =>
                {
                    b.Property<int>("PriceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PriceID"));

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriceID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Services", b =>
                {
                    b.Property<int>("ServicesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicesID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServicesID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Price", b =>
                {
                    b.HasOne("RandevuSistemi.Models.AdminSiniflar.Category", "Category")
                        .WithMany("Price")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RandevuSistemi.Models.AdminSiniflar.Category", b =>
                {
                    b.Navigation("Price");
                });
#pragma warning restore 612, 618
        }
    }
}
