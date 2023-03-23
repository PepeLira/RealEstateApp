﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateApp.Data;

#nullable disable

namespace RealEstateApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230323014510_ChangeInscriptionType")]
    partial class ChangeInscriptionType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealEstateApp.Models.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoyaltyPer")
                        .HasColumnType("int");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UnaccreditedRoyaltyPer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Rut")
                        .IsUnique();

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("RealEstateApp.Models.Inscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Block")
                        .HasColumnType("int");

                    b.Property<string>("Buyer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Commune")
                        .HasColumnType("int");

                    b.Property<string>("Fojas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InscriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InscriptionNumber")
                        .HasColumnType("int");

                    b.Property<string>("Property")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seller")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("RealEstateApp.Models.MultiOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Block")
                        .HasColumnType("int");

                    b.Property<string>("Commune")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FinalEffectiveYear")
                        .HasColumnType("int");

                    b.Property<int>("Fojas")
                        .HasColumnType("int");

                    b.Property<int>("InitialEffectiveYear")
                        .HasColumnType("int");

                    b.Property<DateTime>("InscriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InscriptionNumber")
                        .HasColumnType("int");

                    b.Property<int>("InscriptionYear")
                        .HasColumnType("int");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Property")
                        .HasColumnType("int");

                    b.Property<int>("RoyaltyPer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MultiOwners");
                });

            modelBuilder.Entity("RealEstateApp.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoyaltyPer")
                        .HasColumnType("int");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UnaccreditedRoyaltyPer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Rut")
                        .IsUnique();

                    b.ToTable("Sellers");
                });
#pragma warning restore 612, 618
        }
    }
}
