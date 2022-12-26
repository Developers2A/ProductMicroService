using MediatR;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.Common.Queries.GetCities
{
    public class GetCourierCitiesQuery : IRequest<List<CourierCityDto>>
    {
        public int CourierCode { get; set; }
        public int StateId { get; set; }
    }
}