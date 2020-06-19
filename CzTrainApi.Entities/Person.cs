using CzTrainApi.Common;
using System;
using System.Collections.Generic;

namespace CzTrainApi.Entities
{
    public class Person : BaseEntity
    {
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public DateTime Geburtstag { get; set; }

        public long? AnredeId { get; set; }
        public Anrede Anrede { get; set; }

        public ICollection<Adresse> Adressen { get; set; }
        public ICollection<Benutzer> Benutzer { get; set; }
        public ICollection<Kunde> Kunden { get; set; }
    }
}
