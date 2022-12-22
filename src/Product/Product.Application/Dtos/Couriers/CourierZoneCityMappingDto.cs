﻿using Product.Domain.Enums;

namespace Product.Application.Dtos.Couriers
{
    public class CourierZoneCityMappingDto
    {
        public int CourierZoneId { get; set; }
        public int CityId { get; set; }
        public CourierCode CourierCode { get; set; }
        //public City City { get; set; }
    }
}