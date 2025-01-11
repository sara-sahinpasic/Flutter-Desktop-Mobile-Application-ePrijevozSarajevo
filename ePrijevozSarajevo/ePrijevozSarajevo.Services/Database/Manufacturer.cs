namespace ePrijevozSarajevo.Services.Database
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public Country? ManufacturerCountry { get; set; }
        public int ManufacturerCountryId { get; set; }
    }
}
