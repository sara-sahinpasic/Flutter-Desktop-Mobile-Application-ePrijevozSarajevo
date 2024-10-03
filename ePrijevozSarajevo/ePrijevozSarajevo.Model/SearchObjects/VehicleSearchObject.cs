namespace ePrijevozSarajevo.Model.SearchObjects
{
    public class VehicleSearchObject : BaseSearchObject
    {
        public string? RegistrationNumberGTE { get; set; }
        public bool? IsManufacturerIncluded { get; set; }
        public bool? IsVehicleTypeIncluded { get; set; }
    }
}
