using MediatR;
using Postex.Product.Application.Dtos.Commons;
using System.Text.Json.Serialization;

namespace Postex.Product.Application.Features.Cities.Queries.GetCitiesCommon
{
    public class GetCitiesCommonQuery : IRequest<List<CityCommonDto>>
    {
        [JsonPropertyName("province_code")]
        public int ProvinceCode { get; set; }
    }
}