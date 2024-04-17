using System.ComponentModel.DataAnnotations;

namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class RouteSearchObject : BaseSearchObject
    {
        //public int StartStationId { get; set; }
        public Station? StartStationGTE { get; set; } 
        //public int EndStationId { get; set; }
        public Station? EndStationGTE { get; set; } 
        public bool? IsStartStationIncluded { get; set; }
        public bool? IsEndStationIncluded { get; set; }

    }
}
