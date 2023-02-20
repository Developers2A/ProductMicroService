using MediatR;
using Postex.Product.Application.Dtos.Commons;

namespace Postex.Product.Application.Features.Cities.Queries.GetCitiesCommon
{
    public class GetCitiesCommonQuery : IRequest<List<CityCommonDto>>
    {
        public int StateCode { get; set; }
    }
}