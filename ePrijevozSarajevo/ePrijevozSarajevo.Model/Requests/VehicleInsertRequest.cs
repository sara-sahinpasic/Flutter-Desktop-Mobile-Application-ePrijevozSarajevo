namespace ePrijevozSarajevo.Model.Requests
{
    public class VehicleInsertRequest
    {
        public string? RegistrationNumber { get; set; }
        public int ManufacturerId { get; set; }
        public int VehicleTypeId { get; set; }
        public int BuildYear { get; set; }
    }
}
