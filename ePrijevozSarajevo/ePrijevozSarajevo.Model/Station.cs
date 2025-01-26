namespace ePrijevozSarajevo.Model
{
    public class Station
    {
        public int StationId { get; set; }
        public string? Name { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
