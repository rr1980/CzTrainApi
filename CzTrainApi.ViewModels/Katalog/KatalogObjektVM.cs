using System;
using System.Collections.Generic;
using System.Text;

namespace CzTrainApi.ViewModels.Katalog
{
    public class KatalogObjektVM
    {
        public long Id { get; set; }
        public bool Geloescht { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public DateTime? Aenderungsdatum { get; set; }

        public string Bezeichnung { get; set; }
        public string Discriminator { get; set; }
    }
}
