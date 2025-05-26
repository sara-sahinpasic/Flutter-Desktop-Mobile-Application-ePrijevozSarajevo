namespace ePrijevozSarajevo.Model.Requests
{
    public class RadniProstorUpsertRequest
    {
        public int RadniProstorId { get; set; }
        public string Oznaka { get; set; } = null!;
        public int Kapacitet { get; set; }
        public bool Aktivna { get; set; }
    }
}
