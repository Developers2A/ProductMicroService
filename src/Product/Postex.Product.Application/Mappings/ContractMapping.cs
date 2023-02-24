using AutoMapper;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractCods.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractInfos.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractInfos.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractItems.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractLeasingWarranties.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractLeasingWarranties.Commands.Update;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Application.Mappings
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
