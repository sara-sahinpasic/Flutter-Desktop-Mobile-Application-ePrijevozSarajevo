namespace ePrijevozSarajevo.Model.Requests
{
    public class StationInsertRequest
    {
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        //public DateTime Date { get; set; } = DateTime.Today.Date;
        //public TimeSpan Time { get; set; } = DateTime.Now.TimeOfDay;
    }
}
