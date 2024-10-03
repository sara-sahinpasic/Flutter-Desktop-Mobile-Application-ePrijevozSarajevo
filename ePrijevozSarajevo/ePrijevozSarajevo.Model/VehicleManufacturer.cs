namespace ePrijevozSarajevo.Model
{
    public class VehicleManufacturer
    {
        public int VehicleManufacturerId { get; set; }
        public int VehicleId { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; } = null!;
    }
}
