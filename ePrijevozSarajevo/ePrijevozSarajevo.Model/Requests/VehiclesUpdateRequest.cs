namespace ePrijevozSarajevo.Model.Requests
{
    public class VehiclesUpdateRequest
    {
        public string? RegistrationNumber { get; set; }
        public int ManufacturerId { get; set; }
        public int VehicleTypeId { get; set; }
        public int BuildYear { get; set; }
    }
}
