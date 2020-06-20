using System.Collections.Generic;

namespace CzTrainApi.Entities
{
    public class Titel : KatalogObjekt
    {
        public ICollection<Person> Personen { get; set; }
    }
}
