using AutoMapper;
using Postex.Contract.Application.Dtos;
using Postex.Contract.Application.Features.ContractCods.Command.Create;
using Postex.Contract.Application.Features.ContractLeasingWarranties.Command.Create;
using Postex.Contract.Application.Features.ContractLeasingWarranties.Commands.Update;
using Postex.Contract.Domain;

namespace Postex.Contract.Application.Mapping
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
