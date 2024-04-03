namespace ePrijevozSarajevo.Model.Requests
{
    public class VehicleUpdateRequest
    {
        public string? RegistrationNumber { get; set; }
        public int ManufacturerId { get; set; }
        public int VehicleTypeId { get; set; }
        public int BuildYear { get; set; }
    }
}
