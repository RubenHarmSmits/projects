﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace SogyoLunchApp.Migrations
{
    [DbContext(typeof(LunchAppContext))]
    [Migration("20190418090911_CategorieToegevoegd")]
    partial class CategorieToegevoegd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.Property<int>("Prijs");

                    b.Property<int>("WinkelId");

                    b.HasKey("ProductId");

                    b.HasIndex("WinkelId");

                    b.ToTable("Producten");

                    b.HasData(
                        new
                        {
                            ProductId = -1,
                            Naam = "Kaas",
                            Prijs = 120,
                            WinkelId = 1
                        },
                        new
                        {
                            ProductId = -2,
                            Naam = "Bier",
                            Prijs = 220,
                            WinkelId = 1
                        },
                        new
                        {
                            ProductId = -3,
                            Naam = "Kroket",
                            Prijs = 180,
                            WinkelId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FriendlyName");

                    b.Property<string>("Xml");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");

                    b.HasData(
                        new
                        {
                            Id = "38e2ec3d-c6e2-4d9b-bbf9-ecbd6fe2f9c1",
                            ConcurrencyStamp = "614f27a0-02dd-4296-9988-0d936fa8b564",
                            Name = "User"
                        },
                        new
                        {
                            Id = "9fd0905f-903e-454c-ba91-0b357c6bbf56",
                            ConcurrencyStamp = "af91d961-3b7f-4d12-9fe5-c14bfef17898",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SogyoLunchApp.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SogyoLunchApp.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SogyoLunchApp.Bestelling", b =>
                {
                    b.Property<int>("BestellingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Besteldatum");

                    b.Property<DateTime>("Bezorgdatum");

                    b.Property<Guid>("GebruikerId");

                    b.HasKey("BestellingId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Bestellingen");
                });

            modelBuilder.Entity("SogyoLunchApp.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategorieNaam");

                    b.Property<int?>("VolgordeNummer");

                    b.HasKey("CategorieId");

                    b.ToTable("Categorien");
                });

            modelBuilder.Entity("SogyoLunchApp.ProductenPerBestelling", b =>
                {
                    b.Property<int>("BestellingId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Aantal");

                    b.Property<string>("Notitie");

                    b.Property<int>("Prijs");

                    b.HasKey("BestellingId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductenPerBestellingen");
                });

            modelBuilder.Entity("SogyoLunchApp.StandaardWinkelPerBezorgdag", b =>
                {
                    b.Property<int>("Dag");

                    b.Property<int?>("BestelDeadlineDag");

                    b.Property<TimeSpan>("BestelDeadlineTijd");

                    b.Property<int?>("WinkelId");

                    b.HasKey("Dag");

                    b.HasIndex("WinkelId");

                    b.ToTable("StandaardWinkelsPerBezorgdagen");

                    b.HasData(
                        new
                        {
                            Dag = 1,
                            BestelDeadlineDag = 5,
                            BestelDeadlineTijd = new TimeSpan(0, 11, 0, 0, 0),
                            WinkelId = 1
                        },
                        new
                        {
                            Dag = 2,
                            BestelDeadlineTijd = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Dag = 3,
                            BestelDeadlineDag = 1,
                            BestelDeadlineTijd = new TimeSpan(0, 11, 0, 0, 0),
                            WinkelId = 1
                        },
                        new
                        {
                            Dag = 4,
                            BestelDeadlineTijd = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Dag = 5,
                            BestelDeadlineDag = 5,
                            BestelDeadlineTijd = new TimeSpan(0, 11, 0, 0, 0),
                            WinkelId = 2
                        },
                        new
                        {
                            Dag = 6,
                            BestelDeadlineTijd = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Dag = 0,
                            BestelDeadlineTijd = new TimeSpan(0, 0, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("SogyoLunchApp.Winkel", b =>
                {
                    b.Property<int>("WinkelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Winkellocatie");

                    b.Property<string>("Winkelnaam")
                        .IsRequired();

                    b.HasKey("WinkelId");

                    b.ToTable("Winkels");

                    b.HasData(
                        new
                        {
                            WinkelId = 1,
                            Winkelnaam = "Albert Heijn Bezorgservice"
                        },
                        new
                        {
                            WinkelId = 2,
                            Winkelnaam = "snackbar"
                        });
                });

            modelBuilder.Entity("SogyoLunchApp.WinkelUitzonderingenPerBezorgdag", b =>
                {
                    b.Property<DateTime>("Date");

                    b.Property<DateTime?>("BestelDeadline");

                    b.Property<int?>("WinkelId");

                    b.HasKey("Date");

                    b.HasIndex("WinkelId");

                    b.ToTable("WinkelUitzonderingenPerBezorgdagen");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.HasOne("SogyoLunchApp.Winkel", "Winkel")
                        .WithMany()
                        .HasForeignKey("WinkelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("SogyoLunchApp.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SogyoLunchApp.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SogyoLunchApp.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("SogyoLunchApp.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SogyoLunchApp.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SogyoLunchApp.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SogyoLunchApp.Bestelling", b =>
                {
                    b.HasOne("SogyoLunchApp.AppUser", "Gebruiker")
                        .WithMany()
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SogyoLunchApp.ProductenPerBestelling", b =>
                {
                    b.HasOne("SogyoLunchApp.Bestelling")
                        .WithMany("ProductenPerBestellingen")
                        .HasForeignKey("BestellingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SogyoLunchApp.StandaardWinkelPerBezorgdag", b =>
                {
                    b.HasOne("SogyoLunchApp.Winkel", "Winkel")
                        .WithMany()
                        .HasForeignKey("WinkelId");
                });

            modelBuilder.Entity("SogyoLunchApp.WinkelUitzonderingenPerBezorgdag", b =>
                {
                    b.HasOne("SogyoLunchApp.Winkel", "Winkel")
                        .WithMany()
                        .HasForeignKey("WinkelId");
                });
#pragma warning restore 612, 618
        }
    }
}