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
    [Migration("20190417112200_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Gebruiker", b =>
                {
                    b.Property<int>("GebruikerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achternaam");

                    b.Property<string>("Email");

                    b.Property<bool>("IsAdministrator");

                    b.Property<string>("Voornaam");

                    b.HasKey("GebruikerId");

                    b.ToTable("Gebruikers");

                    b.HasData(
                        new
                        {
                            GebruikerId = 1,
                            Achternaam = "Gebruiker",
                            IsAdministrator = false,
                            Voornaam = "Test"
                        },
                        new
                        {
                            GebruikerId = 2,
                            Achternaam = "van den Oord",
                            IsAdministrator = false,
                            Voornaam = "Bart"
                        });
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategorieId");

                    b.Property<string>("Naam");

                    b.Property<int>("Prijs");

                    b.Property<int>("WinkelId");

                    b.HasKey("ProductId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("WinkelId");

                    b.ToTable("Producten");

                    b.HasData(
                        new
                        {
                            ProductId = -1,
                            CategorieId = 0,
                            Naam = "Kaas",
                            Prijs = 120,
                            WinkelId = 1
                        },
                        new
                        {
                            ProductId = -2,
                            CategorieId = 0,
                            Naam = "Bier",
                            Prijs = 220,
                            WinkelId = 1
                        },
                        new
                        {
                            ProductId = -3,
                            CategorieId = 0,
                            Naam = "Kroket",
                            Prijs = 180,
                            WinkelId = 2
                        });
                });

            modelBuilder.Entity("SogyoLunchApp.Bestelling", b =>
                {
                    b.Property<int>("BestellingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Besteldatum");

                    b.Property<DateTime>("Bezorgdatum");

                    b.Property<int>("GebruikerId");

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

                    b.Property<int>("WinkelId");

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
                    b.HasOne("SogyoLunchApp.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SogyoLunchApp.Winkel", "Winkel")
                        .WithMany()
                        .HasForeignKey("WinkelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SogyoLunchApp.Bestelling", b =>
                {
                    b.HasOne("Domain.Gebruiker", "Gebruiker")
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
