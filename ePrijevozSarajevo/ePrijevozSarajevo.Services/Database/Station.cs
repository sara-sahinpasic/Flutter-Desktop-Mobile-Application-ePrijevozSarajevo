namespace ePrijevozSarajevo.Services.Database
{
    public class Station
    {
        public int StationId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? Date { get; set; } = DateTime.Today.Date;
        public TimeSpan? Time { get; set; } = DateTime.Now.TimeOfDay;
    }
}
