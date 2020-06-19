using CzTrainApi.Common;
using System;
using System.Collections.Generic;

namespace CzTrainApi.Entities
{
    public class Anrede : BaseEntity
    {
        public string Bezeichnung { get; set; }

        public ICollection<Person> Personen { get; set; }
    }
}
