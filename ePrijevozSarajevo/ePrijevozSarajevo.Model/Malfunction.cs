namespace ePrijevozSarajevo.Model
{
    public class Malfunction
    {
        public int MalfunctionId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime? DateOfMalufunction { get; set; }
        public bool? Fixed { get; set; }
        public Vehicle? Vehicle { get; set; } 
        public int? VehicleId { get; set; }
        public Station? Station { get; set; }
        public int? StationId{ get; set; }
    }
}
