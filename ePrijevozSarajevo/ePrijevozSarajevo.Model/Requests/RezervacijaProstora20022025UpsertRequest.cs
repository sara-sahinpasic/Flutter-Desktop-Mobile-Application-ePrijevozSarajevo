namespace ePrijevozSarajevo.Model.Requests
{
    public class RezervacijaProstora20022025UpsertRequest
    {
        public int? RezervacijaProstora20022025Id { get; set; }

        public int? UserId { get; set; }
        public DateTime? PocetakRezervacije { get; set; }
        public DateTime? TrajanjeRezervacije { get; set; }
        public string? Napomena { get; set; } = null!;

        public int? RadniProstorId { get; set; }

        public int? StatusRezervacijeId { get; set; }
    }
}
