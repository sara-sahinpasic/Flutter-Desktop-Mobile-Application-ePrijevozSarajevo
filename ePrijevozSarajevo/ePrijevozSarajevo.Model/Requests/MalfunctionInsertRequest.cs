namespace ePrijevozSarajevo.Model.Requests
{
    public class MalfunctionInsertRequest
    {
        public string Description { get; set; } = null!;
        public DateTime? DateOfMalufunction { get; set; }
        public bool? Fixed { get; set; }
        public int? VehicleId { get; set; }
        public int? StationId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
