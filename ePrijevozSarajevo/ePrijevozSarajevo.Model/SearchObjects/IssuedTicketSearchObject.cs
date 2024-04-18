namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class IssuedTicketSearchObject : BaseSearchObject
    {
        public int IssuedTicketIdGTE { get; set; }
        public bool? IsUserIncluded { get; set; }
        public bool? IsTicketIncluded { get; set; }
    }
}
