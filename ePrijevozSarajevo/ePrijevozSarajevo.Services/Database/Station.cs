namespace ePrijevozSarajevo.Services.Database
{
    public class Station
    {
        public int StationId { get; set; }
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
