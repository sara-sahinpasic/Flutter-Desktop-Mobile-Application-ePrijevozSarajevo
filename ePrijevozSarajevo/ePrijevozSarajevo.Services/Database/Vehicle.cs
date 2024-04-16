namespace ePrijevozSarajevo.Services.Database
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int Number { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; } = null!;
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; } = null!;
        public int BuildYear { get; set; }
    }
}
