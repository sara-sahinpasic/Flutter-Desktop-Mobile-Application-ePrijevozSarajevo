namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class StationSearchObject : BaseSearchObject
    {
        public string? NameGTE { get; set; }
        public DateTime DateGTE { get; set; }
    }
}
