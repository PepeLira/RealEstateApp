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
    [Migration("20230323221919_ReferenceBuyerSellerToInscription")]
    partial class ReferenceBuyerSellerToInscription
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

                    b.Property<int>("RoyaltyPercentage")
                        .HasColumnType("int");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UnaccreditedRoyaltyPercentage")
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

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

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

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

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

                    b.Property<int>("Commune")
                        .HasColumnType("int");

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

                    b.Property<int>("RoyaltyPercentage")
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

                    b.Property<int>("RoyaltyPercentage")
                        .HasColumnType("int");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UnaccreditedRoyaltyPercentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Rut")
                        .IsUnique();

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("RealEstateApp.Models.Inscription", b =>
                {
                    b.HasOne("RealEstateApp.Models.Buyer", "Buyer")
                        .WithMany("Inscriptions")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstateApp.Models.Seller", "Seller")
                        .WithMany("Inscriptions")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("RealEstateApp.Models.Buyer", b =>
                {
                    b.Navigation("Inscriptions");
                });

            modelBuilder.Entity("RealEstateApp.Models.Seller", b =>
                {
                    b.Navigation("Inscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}