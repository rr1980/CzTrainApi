namespace CzTrainApi.Entities
{
    public class Kunde : BaseEntity
    {
        public string KundenNummer { get; set; }

        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
