namespace ePrijevozSarajevo.Model.Requests
{
    public class VehicleInsertRequest
    {
        public int? Number { get; set; }
        public string? RegistrationNumber { get; set; }
        public int? BuildYear { get; set; }
        public int? ManufacturerId { get; set; }
        public int? TypeId { get; set; }
    }
}
