namespace ePrijevozSarajevo.Services.Database
{
    public class Station
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
