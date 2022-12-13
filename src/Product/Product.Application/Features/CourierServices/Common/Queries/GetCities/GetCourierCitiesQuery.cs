﻿using MediatR;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.CourierServices.Common.Queries.GetCities
{
    public class GetCourierCitiesQuery : IRequest<List<CourierCityDto>>
    {
        public int CourierId { get; set; }
        public int StateId { get; set; }
    }
}