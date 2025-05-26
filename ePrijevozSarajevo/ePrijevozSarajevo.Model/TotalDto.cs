namespace ePrijevozSarajevo.Model
{
    public class TotalDto
    {
        public int CountStatusa { get; set; }
        public StatusRezervacije StatusRezervacije { get; set; } = null!;
        public int StatusRezervacijeId { get; set; }
    }
}
