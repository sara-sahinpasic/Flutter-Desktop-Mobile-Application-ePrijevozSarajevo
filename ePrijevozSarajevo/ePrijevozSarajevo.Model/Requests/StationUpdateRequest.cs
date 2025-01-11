namespace ePrijevozSarajevo.Model.Requests
{
    public class StationUpdateRequest
    {
        public string? Name { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
