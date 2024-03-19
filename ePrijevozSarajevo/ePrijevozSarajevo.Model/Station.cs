namespace ePrijevozSarajevo.Model
{
    public class Station
    {
        public int StationId { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
