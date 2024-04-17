using System.Xml.Linq;

namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class RequestSearchObject : BaseSearchObject
    {
        public int? UserStatusIdFTS { get; set; }
        //public Status? UserStatusFTS { get; set; } = null!;
        public int? UserIdFTS { get; set; }
        //public User User { get; set; } = null!;
        public bool? IsUserIncluded { get; set; }
        //public bool? IsUserStatusIncluded { get; set; }


    }
}
