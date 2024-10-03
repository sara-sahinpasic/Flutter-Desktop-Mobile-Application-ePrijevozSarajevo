namespace ePrijevozSarajevo.Services.Database
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int Number { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public int BuildYear { get; set; }
        
        public Manufacturer? Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public Type? Type { get; set; }
        public int TypeId { get; set; }

       // public virtual ICollection<VehicleManufacturer> VehicleManufacturers { get; set; } = new List<VehicleManufacturer>();
        //public virtual ICollection<VehicleType> VehicleTypes { get; set; } = new List<VehicleType>();
    }
}
