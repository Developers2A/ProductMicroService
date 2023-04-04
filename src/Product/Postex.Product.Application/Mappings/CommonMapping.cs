using AutoMapper;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.ValueAddeds;
using Postex.Product.Domain.Common;
using Postex.Product.Domain.Couriers;
using Postex.Product.Domain.Locations;

namespace Postex.Product.Application.Mappings
{
    public class CommonMapping : Profile
    {
        public CommonMapping()
        {
            CreateMap<BoxType, BoxTypeDto>();
            CreateMap<Zone, ZoneDto>();
            CreateMap<Weight, WeightDto>();
            CreateMap<ValueAddedType, ValueAddedTypeDto>();
        }
    }
}
