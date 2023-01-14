using AutoMapper;
using Postex.Contract.Application.Dtos;
using Postex.Contract.Domain;

namespace Postex.Contract.Application.Mapping
{
    public class ContractMapping : Profile
    {
        public ContractMapping()
        {
            CreateMap<ContractItemType, ContractItemTypeDto>();
        }
    }
}
