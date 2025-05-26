namespace ePrijevozSarajevo.Services.Database
{
    public class RezervacijaProstora20022025
    {
        public int RezervacijaProstora20022025Id { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime PocetakRezervacije { get; set; }
        public DateTime TrajanjeRezervacije { get; set; }
        public string Napomena { get; set; } = null!;
        public RadniProstor RadniProstor { get; set; } = null!;
        public int RadniProstorId { get; set; }
        public StatusRezervacije StatusRezervacije { get; set; } = null!;
        public int StatusRezervacijeId { get; set; }
    }
}
