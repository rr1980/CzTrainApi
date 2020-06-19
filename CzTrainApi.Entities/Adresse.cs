using CzTrainApi.Common;
using System;

namespace CzTrainApi.Entities
{
    public class Adresse : BaseEntity
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }

        public string Strasse { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public int Hausnummer { get; set; }
        public string Hausnummerzusatz { get; set; }
    }
}
