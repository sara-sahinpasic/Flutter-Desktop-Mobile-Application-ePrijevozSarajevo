namespace ePrijevozSarajevo.Model.Requests
{
    public class ManufacturerUpsertRequest
    {
        public string? Name { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ManufacturerCountryId { get; set; }
    }
}
