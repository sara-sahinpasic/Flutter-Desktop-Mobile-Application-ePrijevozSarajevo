namespace ePrijevozSarajevo.Services.Database
{
public class Type
    {
        public int TypeId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
