using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetContractById
{

    public class GetContractByIdQueryHandler : IRequestHandler<GetContractByIdQuery, ContractInfoDto>
    {
        private readonly IReadRepository<ContractInfo> _readRepository;
        private readonly IMapper _mapper;

        public GetContractByIdQueryHandler(IReadRepository<ContractInfo> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<ContractInfoDto> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
        {
            var info = await _readRepository.Table
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
                })
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            return info;
        }
    }


}
