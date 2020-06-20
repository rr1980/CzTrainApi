using System;
using System.Collections.Generic;

namespace CzTrainApi.ViewModels.Test
{
    public class TestKatalogObjekteResponseVM
    {
        public long Id { get; set; }
        public string Discriminator { get; set; }
        public string Bezeichnung { get; set; }
        public bool Geloescht { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public DateTime? Aenderungsdatum { get; set; }
    }

    //public class TestKatalogObjekteResponseVM
    //{
    //    public long Id { get; set; }
    //    public string Discriminator { get; set; }
    //    public string Bezeichnung { get; set; }

    //    public IList<TestKatalogObjektePersonenResponseVM> Personen_Anrede { get; set; }
    //    public IList<TestKatalogObjektePersonenResponseVM> Personen_Titel { get; set; }
    //}

    //public class TestKatalogObjektePersonenResponseVM
    //{
    //    public long Id { get; set; }
    //    public string FullName { get; set; }
    //    public string Benutzername { get; set; }
    //}
}
