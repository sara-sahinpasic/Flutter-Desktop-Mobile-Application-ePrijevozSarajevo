﻿namespace ePrijevozSarajevo.Model.Requests
{
    public class StatusUpdateRequest
    {
        public string? Name { get; set; }
        public double Discount { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
