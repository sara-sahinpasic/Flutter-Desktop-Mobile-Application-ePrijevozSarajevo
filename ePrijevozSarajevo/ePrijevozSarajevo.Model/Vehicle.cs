namespace ePrijevozSarajevo.Model
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int Number { get; set; }
        public string? RegistrationNumber { get; set; }
        public int BuildYear { get; set; }
        public VehicleType? VehicleType { get; set; }
        public Manufacturer? Manufacturer { get; set; }

    }
}
