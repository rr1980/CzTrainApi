﻿// <auto-generated />
using System;
using CzTrainApi.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CzTrainApi.Db.Migrations
{
    [DbContext(typeof(DatenbankContext))]
    [Migration("20200620004552_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CzTrainApi.Entities.Adresse", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Aenderungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Erstellungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Geloescht")
                        .HasColumnType("bit");

                    b.Property<int>("Hausnummer")
                        .HasColumnType("int");

                    b.Property<string>("Hausnummerzusatz")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Ort")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Plz")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Strasse")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("Adressen");
                });

            modelBuilder.Entity("CzTrainApi.Entities.Benutzer", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Aenderungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("BenutzerRolle")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Benutzername")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Erstellungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Geloescht")
                        .HasColumnType("bit");

                    b.Property<string>("Passwort")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("Benutzer");
                });

            modelBuilder.Entity("CzTrainApi.Entities.KatalogObjekt", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Aenderungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Erstellungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Geloescht")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("KatalogObjekte");

                    b.HasDiscriminator<string>("Discriminator").HasValue("KatalogObjekt");
                });

            modelBuilder.Entity("CzTrainApi.Entities.Kunde", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Aenderungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Erstellungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Geloescht")
                        .HasColumnType("bit");

                    b.Property<string>("KundenNummer")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("Kunden");
                });

            modelBuilder.Entity("CzTrainApi.Entities.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Aenderungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<long?>("AnredeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Erstellungsdatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Geburtstag")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Geloescht")
                        .HasColumnType("bit");

                    b.Property<string>("Nachname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long?>("TitelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AnredeId");

                    b.HasIndex("TitelId");

                    b.ToTable("Personen");
                });

            modelBuilder.Entity("CzTrainApi.Entities.Anrede", b =>
                {
                    b.HasBaseType("CzTrainApi.Entities.KatalogObjekt");

                    b.HasDiscriminator().HasValue("Anrede");
                });

            modelBuilder.Entity("CzTrainApi.Entities.Titel", b =>
                {
                    b.HasBaseType("CzTrainApi.Entities.KatalogObjekt");

                    b.HasDiscriminator().HasValue("Titel");
                });

            modelBuilder.Entity("CzTrainApi.Entities.Adresse", b =>
                {
                    b.HasOne("CzTrainApi.Entities.Person", "Person")
                        .WithMany("Adressen")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CzTrainApi.Entities.Benutzer", b =>
                {
                    b.HasOne("CzTrainApi.Entities.Person", "Person")
                        .WithMany("Benutzer")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CzTrainApi.Entities.Kunde", b =>
                {
                    b.HasOne("CzTrainApi.Entities.Person", "Person")
                        .WithMany("Kunden")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CzTrainApi.Entities.Person", b =>
                {
                    b.HasOne("CzTrainApi.Entities.Anrede", "Anrede")
                        .WithMany("Personen")
                        .HasForeignKey("AnredeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("CzTrainApi.Entities.Titel", "Titel")
                        .WithMany("Personen")
                        .HasForeignKey("TitelId")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}