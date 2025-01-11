namespace ePrijevozSarajevo.Services.Database
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; } = null!;
        public double Discount { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
