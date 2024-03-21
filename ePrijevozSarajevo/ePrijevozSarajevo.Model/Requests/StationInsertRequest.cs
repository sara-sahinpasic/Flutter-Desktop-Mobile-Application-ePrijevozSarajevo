namespace ePrijevozSarajevo.Model.Requests
{
    public class StationInsertRequest
    {
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
