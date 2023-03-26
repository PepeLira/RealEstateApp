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
    [Migration("20230326195046_FixInscriptionSellerBuyerRelation")]
    partial class FixInscriptionSellerBuyerRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuyerInscription", b =>
                {
                    b.Property<int>("BuyersId")
                        .HasColumnType("int");

                    b.Property<int>("InscriptionsId")
                        .HasColumnType("int");

                    b.HasKey("BuyersId", "InscriptionsId");

                    b.HasIndex("InscriptionsId");

                    b.ToTable("BuyerInscription");
                });

            modelBuilder.Entity("InscriptionSeller", b =>
                {
                    b.Property<int>("InscriptionsId")
                        .HasColumnType("int");

                    b.Property<int>("SellersId")
                        .HasColumnType("int");

                    b.HasKey("InscriptionsId", "SellersId");

                    b.HasIndex("SellersId");

                    b.ToTable("InscriptionSeller");
                });

            modelBuilder.Entity("RealEstateApp.Models.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("Buyer", (string)null);
                });

            modelBuilder.Entity("RealEstateApp.Models.Inscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Block")
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

                    b.HasKey("Id");

                    b.ToTable("Inscription", (string)null);
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

                    b.Property<int?>("FinalEffectiveYear")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("Seller", (string)null);
                });

            modelBuilder.Entity("BuyerInscription", b =>
                {
                    b.HasOne("RealEstateApp.Models.Buyer", null)
                        .WithMany()
                        .HasForeignKey("BuyersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstateApp.Models.Inscription", null)
                        .WithMany()
                        .HasForeignKey("InscriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InscriptionSeller", b =>
                {
                    b.HasOne("RealEstateApp.Models.Inscription", null)
                        .WithMany()
                        .HasForeignKey("InscriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstateApp.Models.Seller", null)
                        .WithMany()
                        .HasForeignKey("SellersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}