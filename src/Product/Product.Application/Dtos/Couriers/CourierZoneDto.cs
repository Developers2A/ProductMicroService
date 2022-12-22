﻿using Product.Domain.Enums;

namespace Product.Application.Dtos.Couriers
{
    public class CourierZoneDto
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public string Name { get; set; }
        public CityTypeCode Code { get; set; }
    }
}