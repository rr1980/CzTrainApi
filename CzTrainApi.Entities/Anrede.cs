using CzTrainApi.Common;
using CzTrainApi.Common.BaseTypes;
using System;
using System.Collections.Generic;

namespace CzTrainApi.Entities
{
    public class Anrede : KatalogObjekt
    {
        public ICollection<Person> Personen { get; set; }
    }
}
