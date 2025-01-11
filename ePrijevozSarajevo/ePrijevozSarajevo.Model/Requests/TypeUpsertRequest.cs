namespace ePrijevozSarajevo.Model.Requests
{
    public class TypeUpsertRequest
    {
        public string? Name { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
