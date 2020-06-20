using System;
using System.Reflection.PortableExecutable;

namespace CzTrainApi.Common.BaseTypes
{
    public interface IEntity
    {
        long Id { get; set; }
        bool Geloescht { get; set; }
        DateTime Erstellungsdatum { get; set; }
        DateTime? Aenderungsdatum { get; set; }
    }

    public interface IKatalogObjekt : IEntity
    {
        public string Bezeichnung { get; set; }
        public string Discriminator { get; set; }
    }
}
