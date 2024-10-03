namespace ePrijevozSarajevo.Model
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public int VehicleId { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set; } = null!;
    }
}
