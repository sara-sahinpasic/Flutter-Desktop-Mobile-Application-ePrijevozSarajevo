namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class RouteSearchObject : BaseSearchObject
    {
        public int StartStationIdGTE { get; set; }
        public int? EndStationIdGTE { get; set; }
        public DateTime DateGTE { get; set; }
        public bool IsStationIncluded { get; set; }
        public bool IsVehicleIncluded { get; set; }
        public bool IsMobileSearch { get; set; }

    }
}
