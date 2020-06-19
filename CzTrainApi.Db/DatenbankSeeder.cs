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

        private static void Seed_Person(DatenbankContext context)
        {
            if (!context.Personen.Any())
            {
                context.Personen.Add(new Person
                {
                    Nachname = "Mustermann",
                    Vorname = "Max",
                    Geburtstag = DateTime.Now,
                    Anrede = context.Anreden.SingleOrDefault(x => x.Bezeichnung == "Herr")
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
                    Passwort = "12003",
                    BenutzerRolle = "Nutzer",

                    Person = context.Personen.SingleOrDefault(x => x.Nachname == "Mustermann")
                });

                context.SaveChanges();
            }
        }
    }
}
