﻿namespace ePrijevozSarajevo.Services.Database
{
    public class Station
    {
        public int StationId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
