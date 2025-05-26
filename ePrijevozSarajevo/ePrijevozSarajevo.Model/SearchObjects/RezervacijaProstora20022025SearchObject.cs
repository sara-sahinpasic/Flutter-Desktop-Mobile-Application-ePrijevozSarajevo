namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class RezervacijaProstora20022025SearchObject : BaseSearchObject
    {
        public int? UserId { get; set; }
        public int? RadniProstorId { get; set; }
        public DateTime? PocetakRezervacije { get; set; }
        public DateTime? TrajanjeRezervacije { get; set; }
        public string? Napomena { get; set; } = null!;
        //public int? StatusRezervacijeId { get; set; }
    }
}
