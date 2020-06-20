using CzTrainApi.Common.BaseTypes;
using System;

namespace CzTrainApi.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }
        public bool Geloescht { get; set; }
        public DateTime Erstellungsdatum { get; set; } = DateTime.Now;
        public DateTime? Aenderungsdatum { get; set; }
    }
}
