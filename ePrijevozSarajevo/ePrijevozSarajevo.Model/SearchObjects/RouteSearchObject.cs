using System.ComponentModel.DataAnnotations;

namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class RouteSearchObject : BaseSearchObject
    {
        public int StartStationIdGTE { get; set; }
        //public int? EndStationIdGTE { get; set; } -     FOR MOBILE ROUTE_SCREEN

        public DateTime DateGTE { get; set; }
        
        public bool? IsStationIncluded { get; set; }

    }
}
