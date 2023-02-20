using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contracts.Queries.GetContractByCustomer
{

    public class GetContractByCustomerHandler : IRequestHandler<GetContractByCustomer, ContractInfoDto>
    {
        private readonly IReadRepository<ContractInfo> _readRepository;
        private readonly IMapper _mapper;

        public GetContractByCustomerHandler(IReadRepository<ContractInfo> readRepository, IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mapper = mapper;
        }

        public async Task<ContractInfoDto> Handle(GetContractByCustomer request, CancellationToken cancellationToken)
        {
            var info = await _readRepository.Table
                                            .Include(c=> c.ContractInsurances)
                                            .Include(c=> c.ContractCods)
                                            .Include(c=> c.ContractBoxPrices)                                                         
                .Select(c => new ContractInfoDto
                {
                    Id = c.Id,
                    ContractNo = c.ContractNo,
                    Title = c.Title,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    RegisterDate = c.RegisterDate,
                    CustomerId = c.CustomerId,
                    CityId=c.CityId,
                    ProvinceId  = c.ProvinceId,
                    IsActive = c.IsActive,
                    ContractInsurances = c.ContractInsurances,
                    ContractCods = c.ContractCods,
                    ContractBoxPrices = c.ContractBoxPrices
         

                })
                .Where(c => c.CustomerId == request.CustomerId)
                .FirstOrDefaultAsync(cancellationToken);
            //if (info is null)
            //{
            //     info = await _readRepository.Table
            //    .Select(c => new ContractInfoDto
            //    {
            //        Id = c.Id,
            //        ContractNo = c.ContractNo,
            //        Title = c.Title,
            //        Description = c.Description,
            //        StartDate = c.StartDate,
            //        EndDate = c.EndDate,
            //        RegisterDate = c.RegisterDate,                   
            //    })
            //    .Where(c => c.Ci == request.CustomerId)
            //    .FirstOrDefaultAsync(cancellationToken);
            //}

            return info;
        }
    }


}
