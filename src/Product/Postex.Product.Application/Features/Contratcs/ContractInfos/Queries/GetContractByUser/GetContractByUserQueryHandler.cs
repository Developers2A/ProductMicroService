using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetContractByUser
{
    public class GetContractByUserQueryHandler : IRequestHandler<GetContractByUserQuery, ContractInfoDto>
    {
        private readonly IReadRepository<ContractInfo> _readRepository;
        private readonly IMapper _mapper;

        public GetContractByUserQueryHandler(IReadRepository<ContractInfo> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<ContractInfoDto> Handle(GetContractByUserQuery request, CancellationToken cancellationToken)
        {
            var info = await _readRepository.Table
                                            .Include(c => c.ContractInsurances)
                                            .Include(c => c.ContractCods)
                                            .Include(c => c.ContractBoxPrices)
                .Select(c => new ContractInfoDto
                {
                    Id = c.Id,
                    ContractNo = c.ContractNo,
                    Title = c.Title,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    RegisterDate = c.RegisterDate,
                    UserId = c.UserId,
                    CityId = c.CityId,
                    ProvinceId = c.ProvinceId,
                    IsActive = c.IsActive,
                    ContractInsurances = c.ContractInsurances,
                    ContractCods = c.ContractCods,
                    ContractBoxPrices = c.ContractBoxPrices
                })
                .Where(c => c.UserId == request.UserId)
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
            //    .Where(c => c.Ci == request.UserId)
            //    .FirstOrDefaultAsync(cancellationToken);
            //}

            return info;
        }
    }


}
