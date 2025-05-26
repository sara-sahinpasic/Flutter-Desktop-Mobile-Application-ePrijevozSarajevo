namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class RadniProstorSearchObject : BaseSearchObject
    {
        public int? RadniProstorId { get; set; }
        public string? Oznaka { get; set; } = null!;
        public int? Kapacitet { get; set; }
        public bool? Aktivna { get; set; }
    }
}
