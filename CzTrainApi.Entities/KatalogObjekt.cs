using CzTrainApi.Common.BaseTypes;

namespace CzTrainApi.Entities
{
    public abstract class KatalogObjekt : BaseEntity, IKatalogObjekt
    {
        public string Discriminator { get; set; }
        public string Bezeichnung { get; set; }
    }
}
