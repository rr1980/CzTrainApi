using System;

namespace CzTrainApi.Common.BaseTypes
{
    public interface IEntity
    {
        long Id { get; set; }
        bool Geloescht { get; set; }
        DateTime Erstellungsdatum { get; set; }
        DateTime? Aenderungsdatum { get; set; }
    }
}
