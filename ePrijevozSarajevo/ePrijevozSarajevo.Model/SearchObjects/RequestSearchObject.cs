using System.Xml.Linq;

namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class RequestSearchObject : BaseSearchObject
    {
        //public Status? UserStatusGTE { get; set; } = null!;
        public int? UserStatusIdGTE { get; set; }

        public int? UserIdGTE { get; set; }
        public bool? IsUserIncluded { get; set; }
    }
}
