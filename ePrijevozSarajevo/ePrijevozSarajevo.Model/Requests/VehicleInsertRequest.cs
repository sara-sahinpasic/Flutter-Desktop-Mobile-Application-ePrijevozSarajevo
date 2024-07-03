namespace ePrijevozSarajevo.Model.Requests
{
    public class VehicleInsertRequest
    {
        public string? RegistrationNumber { get; set; }
        public int Number { get; set; }
        public int ManufacturerId { get; set; }
        public int TypeId { get; set; }
        public int BuildYear { get; set; }
    }
}
