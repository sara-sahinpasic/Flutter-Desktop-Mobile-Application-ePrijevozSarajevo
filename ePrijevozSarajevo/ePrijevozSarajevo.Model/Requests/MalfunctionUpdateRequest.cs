﻿namespace ePrijevozSarajevo.Model.Requests
{
    public class MalfunctionUpdateRequest
    {
        public bool? Fixed { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
