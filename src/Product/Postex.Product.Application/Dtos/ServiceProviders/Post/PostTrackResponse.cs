﻿namespace Postex.Product.Application.Dtos.ServiceProviders.Post
{
    public class PostTrackResponse
    {
        public string EventDate { get; set; } // DateOnly
        public string EventTime { get; set; } // TimeOnly
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
