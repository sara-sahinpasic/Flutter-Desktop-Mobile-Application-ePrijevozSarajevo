namespace ePrijevozSarajevo.Model
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string? Name { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ManufacturerCountryId { get; set; }

    }
}
