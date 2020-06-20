using CzTrainApi.Entities;
using System;
using System.Linq;

namespace CzTrainApi.Db
{
    public static class DatenbankSeeder
    {
        public static void Seed(DatenbankContext context)
        {
            Seed_Anrede(context);
            Seed_Titel(context);
            Seed_Person(context);
            Seed_Benutzer(context);
        }

        private static void Seed_Anrede(DatenbankContext context)
        {
            if (!context.Anreden.Any())
            {
                context.Anreden.Add(new Anrede
                {
                    Bezeichnung = "Herr"
                });

                context.Anreden.Add(new Anrede
                {
                    Bezeichnung = "Frau"
                });

                context.SaveChanges();
            }
        }

        private static void Seed_Titel(DatenbankContext context)
        {
            if (!context.Titel.Any())
            {
                context.Titel.Add(new Titel
                {
                    Bezeichnung = "Dr."
                });

                context.Titel.Add(new Titel
                {
                    Bezeichnung = "Prof."
                });

                context.SaveChanges();
            }
        }
        private static void Seed_Person(DatenbankContext context)
        {
            if (!context.Personen.Any())
            {
                context.Personen.Add(new Person
                {
                    Nachname = "Mustermann",
                    Vorname = "Max",
                    Geburtstag = DateTime.Now,
                    Anrede = context.Anreden.SingleOrDefault(x => x.Bezeichnung == "Herr"),
                    Titel = context.Titel.SingleOrDefault(x => x.Bezeichnung == "Dr."),
                });

                context.SaveChanges();
            }
        }

        private static void Seed_Benutzer(DatenbankContext context)
        {
            if (!context.Benutzer.Any())
            {
                context.Benutzer.Add(new Benutzer
                {
                    Benutzername = "Max123",
                    Passwort = "ehYsOxcxE5aCr3qbySIYsm3uxTykAHRK985TtdlK+8U=",
                    BenutzerRolle = "Nutzer",

                    Person = context.Personen.SingleOrDefault(x => x.Nachname == "Mustermann")
                });

                context.SaveChanges();
            }
        }
    }
}
