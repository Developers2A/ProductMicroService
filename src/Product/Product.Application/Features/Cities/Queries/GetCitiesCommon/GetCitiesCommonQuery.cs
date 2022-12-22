using MediatR;
using Product.Application.Dtos.Commons;

namespace Product.Application.Features.Cities.Queries.GetCitiesCommon
{
    public class GetCitiesCommonQuery : IRequest<List<CityCommonDto>>
    {
        public string StateCode { get; set; }
    }
}