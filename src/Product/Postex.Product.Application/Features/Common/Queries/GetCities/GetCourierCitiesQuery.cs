using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;

namespace Postex.Product.Application.Features.Common.Queries.GetCities
{
    public class GetCourierCitiesQuery : IRequest<List<CourierCityDto>>
    {
        public int CourierCode { get; set; }
        public int StateId { get; set; }
    }
}