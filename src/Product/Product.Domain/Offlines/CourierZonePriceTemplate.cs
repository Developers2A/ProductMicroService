﻿using Postex.SharedKernel.Domain;
using Product.Domain.Couriers;

namespace Product.Domain.Offlines
{
    public class CourierZonePriceTemplate : BaseEntity<int>
    {
        public int FromCity { get; set; }
        public int ToCity { get; set; }
        public int CourierServiceId { get; set; }
        public CourierService CourierService { get; set; }
        public int FromCourierZoneId { get; set; }
        public int ToCourierZoneId { get; set; }
        public int Weight { get; set; }
        public bool SameState { get; set; }
    }
}