using CzTrainApi.Common;
using System;

namespace CzTrainApi.Entities
{
    public class Benutzer : BaseEntity
    {
        public string Benutzername { get; set; }
        public string Passwort { get; set; }
        public string BenutzerRolle { get; set; }

        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
