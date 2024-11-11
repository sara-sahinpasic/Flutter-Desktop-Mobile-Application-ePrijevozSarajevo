using System.Xml.Linq;

namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class RequestSearchObject : BaseSearchObject
    {
        public int? UserStatusIdGTE { get; set; }
        public bool? IsUserIncluded { get; set; }
    }
}
