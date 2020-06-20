using CzTrainApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace CzTrainApi.Db
{
    public class DatenbankContext : DbContext
    {
        public virtual DbSet<Person> Personen { get; set; }
        public virtual DbSet<Adresse> Adressen { get; set; }
        public virtual DbSet<Kunde> Kunden { get; set; }
        public virtual DbSet<Benutzer> Benutzer { get; set; }
        public virtual DbSet<KatalogObjekt> KatlogObjekte { get; set; }
        public virtual DbSet<Anrede> Anreden { get; set; }
        public virtual DbSet<Titel> Titel { get; set; }

        public DatenbankContext(DbContextOptions<DatenbankContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(table =>
            {
                table.HasKey(x => x.Id);
                table.Property(e => e.Geloescht);
                table.HasQueryFilter(x => !x.Geloescht);
                table.Property(e => e.Erstellungsdatum);
                table.Property(e => e.Aenderungsdatum);


                table.Property(e => e.Nachname).HasMaxLength(50);
                table.Property(e => e.Vorname).HasMaxLength(50);
                table.Property(e => e.Geburtstag);
            });

            modelBuilder.Entity<KatalogObjekt>(table =>
            {
                table.ToTable("KatalogObjekte");
                table.HasKey(x => x.Id);
                table.Property(e => e.Geloescht);
                table.HasQueryFilter(x => !x.Geloescht);
                table.Property(e => e.Erstellungsdatum);
                table.Property(e => e.Aenderungsdatum);
                table.HasDiscriminator(e => e.Discriminator);
                table.Property(e => e.Bezeichnung).HasMaxLength(50);
            });

            modelBuilder.Entity<Anrede>(table =>
            {
                table.HasMany(x => x.Personen).WithOne(x => x.Anrede).HasForeignKey(x => x.AnredeId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Titel>(table =>
            {
                table.HasMany(x => x.Personen).WithOne(x => x.Titel).HasForeignKey(x=>x.TitelId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Benutzer>(table =>
            {
                table.HasKey(x => new { x.Id, x.PersonId });
                table.Property(e => e.Geloescht);
                table.HasQueryFilter(x => !x.Geloescht);
                table.Property(e => e.Erstellungsdatum);
                table.Property(e => e.Aenderungsdatum);

                table.Property(e => e.Benutzername).HasMaxLength(50);
                table.Property(e => e.Passwort).HasMaxLength(100);
                table.Property(e => e.BenutzerRolle).HasMaxLength(50);

                table.HasOne(x => x.Person).WithMany(x => x.Benutzer).HasForeignKey(x => x.PersonId);
            });

            modelBuilder.Entity<Kunde>(table =>
            {
                table.HasKey(x => new { x.Id, x.PersonId });
                table.Property(e => e.Geloescht);
                table.HasQueryFilter(x => !x.Geloescht);
                table.Property(e => e.Erstellungsdatum);
                table.Property(e => e.Aenderungsdatum);

                table.Property(e => e.KundenNummer).HasMaxLength(50);

                table.HasOne(x => x.Person).WithMany(x => x.Kunden).HasForeignKey(x => x.PersonId);
            });

            modelBuilder.Entity<Adresse>(table =>
            {
                table.HasKey(x => new { x.Id, x.PersonId });
                table.Property(e => e.Geloescht);
                table.HasQueryFilter(x => !x.Geloescht);
                table.Property(e => e.Erstellungsdatum);
                table.Property(e => e.Aenderungsdatum);


                table.Property(e => e.Strasse).HasMaxLength(100);
                table.Property(e => e.Plz).HasMaxLength(10);
                table.Property(e => e.Ort).HasMaxLength(50);
                table.Property(e => e.Hausnummer);
                table.Property(e => e.Hausnummerzusatz).HasMaxLength(10);

                table.HasOne(x => x.Person).WithMany(x => x.Adressen).HasForeignKey(x => x.PersonId);
            });
        }
    }
}
