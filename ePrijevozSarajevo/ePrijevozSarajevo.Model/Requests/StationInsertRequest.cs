namespace ePrijevozSarajevo.Model.Requests
{
    public class StationInsertRequest
    {
        public string? Name { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
