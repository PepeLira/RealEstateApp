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
    [Migration("20230419014808_ChangeInscriptionDataType")]
    partial class ChangeInscriptionDataType
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

            modelBuilder.Entity("RealEstateApp.Models.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InscriptionAttentionID")
                        .HasColumnType("int");

                    b.Property<int>("RoyaltyPercentage")
                        .HasColumnType("int");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UnaccreditedRoyaltyPercentage")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("InscriptionAttentionID");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("RealEstateApp.Models.Commune", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Communes");
                });

            modelBuilder.Entity("RealEstateApp.Models.Inscription", b =>
                {
                    b.Property<int>("AttentionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttentionID"));

                    b.Property<int>("Block")
                        .HasColumnType("int");

                    b.Property<string>("Cne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Commune")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fojas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InscriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InscriptionNumber")
                        .HasColumnType("int");

                    b.Property<int>("Property")
                        .HasColumnType("int");

                    b.HasKey("AttentionID");

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

                    b.Property<string>("Commune")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("InscriptionAttentionID")
                        .HasColumnType("int");

                    b.Property<int>("RoyaltyPercentage")
                        .HasColumnType("int");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UnaccreditedRoyaltyPercentage")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("InscriptionAttentionID");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("RealEstateApp.Models.Buyer", b =>
                {
                    b.HasOne("RealEstateApp.Models.Inscription", "Inscription")
                        .WithMany("Buyers")
                        .HasForeignKey("InscriptionAttentionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscription");
                });

            modelBuilder.Entity("RealEstateApp.Models.Seller", b =>
                {
                    b.HasOne("RealEstateApp.Models.Inscription", "Inscription")
                        .WithMany("Sellers")
                        .HasForeignKey("InscriptionAttentionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscription");
                });

            modelBuilder.Entity("RealEstateApp.Models.Inscription", b =>
                {
                    b.Navigation("Buyers");

                    b.Navigation("Sellers");
                });
#pragma warning restore 612, 618
        }
    }
}
