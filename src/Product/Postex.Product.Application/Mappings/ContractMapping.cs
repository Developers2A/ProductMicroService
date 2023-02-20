using AutoMapper;
using Postex.Product.Application.Dtos;
using Postex.Product.Application.Features.ContractCods.Command.Create;
using Postex.Product.Application.Features.ContractLeasingWarranties.Command.Create;
using Postex.Product.Application.Features.ContractLeasingWarranties.Commands.Update;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Application.Mapping
{
    public class ContractMapping : Profile
    {
        public ContractMapping()
        {
            CreateMap<ContractCod, ContractCodDto>();
            CreateMap<CreateContractCodCommand, ContractCod>();


            CreateMap<CreateContractLeasingWarrantyCommand, ContractLeasingWarranty>();
            CreateMap<UpdateContractLeasingWarrantyCommand, ContractLeasingWarranty>();
        }
    }
}
