namespace ePrijevozSarajevo.Model.Requests
{
    public class StationUpdateRequest
    {
        public string? Name { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
