using AutoMapper;
using Postex.Product.Application.Dtos;
using Postex.Product.Application.Features.ContractBoxPrices.Command.Create;
using Postex.Product.Application.Features.ContractCods.Command.Create;
using Postex.Product.Application.Features.ContractCollect_Distributes.Command.Create;
using Postex.Product.Application.Features.ContractCouriers.Command.Create;
using Postex.Product.Application.Features.ContractInsurances.Command;
using Postex.Product.Application.Features.ContractItems.Commands.CreateContractItem;
using Postex.Product.Application.Features.ContractLeasings.Command.Create;
using Postex.Product.Application.Features.ContractLeasingWarranties.Command.Create;
using Postex.Product.Application.Features.ContractLeasingWarranties.Commands.Update;
using Postex.Product.Application.Features.Contracts.Commands.CreateContractCommand;
using Postex.Product.Application.Features.Contracts.Commands.UpdateContractCommand;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Application.Mapping
{
    public class ContractMapping : Profile
    {
        public ContractMapping()
        {
            CreateMap<ContractBoxPrice, ContractBoxPriceDto>();
            CreateMap<CreateContractBoxPriceCommand, ContractBoxPrice>();

            CreateMap<ContractCod, ContractCodDto>();
            CreateMap<CreateContractCodCommand, ContractCod>();           

            CreateMap<ContractInfo, ContractInfoDto>();
            CreateMap<CreateContractCommand, ContractInfo>();
            CreateMap<UpdateContractCommand, ContractInfo>();

            CreateMap<CreateContractCourierCommand, ContractCourierDto>();
            CreateMap<ContractCourier, ContractCourierDto>();

            CreateMap<ContractInsurance, ContractInsuranceDto>();
            CreateMap<CreateContractInsuranceCommand, ContractInsurance>();

            CreateMap<ContractItem, ContractItemDto>();
            CreateMap<CreateContractItemCommand, ContractItem>();

            CreateMap<ContractCollectionDistribution, ContractCollectionDistributionDto>();
            CreateMap<CreateContractCollect_DistributeCommand, ContractCollectionDistribution>();


            CreateMap<ContractLeasing, ContractLeasingDto>();
            CreateMap<CreateContractLeasingCommand, ContractLeasing>();

            CreateMap<CreateContractLeasingWarrantyCommand, ContractLeasingWarranty>();
            CreateMap<UpdateContractLeasingWarrantyCommand, ContractLeasingWarranty>();

        }
    }
}
