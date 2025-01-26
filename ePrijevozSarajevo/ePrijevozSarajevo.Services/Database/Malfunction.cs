using System.ComponentModel.DataAnnotations;

namespace ePrijevozSarajevo.Services.Database
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
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
