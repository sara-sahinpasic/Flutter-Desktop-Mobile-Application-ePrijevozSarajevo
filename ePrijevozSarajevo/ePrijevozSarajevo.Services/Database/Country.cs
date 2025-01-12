namespace ePrijevozSarajevo.Services.Database
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
