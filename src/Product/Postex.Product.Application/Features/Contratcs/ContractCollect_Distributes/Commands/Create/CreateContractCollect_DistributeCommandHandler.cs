using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Commands.Create
{
    internal class CreateContractCollect_DistributeCommandHandler : IRequestHandler<CreateContractCollect_DistributeCommand, ContractCollectionDistributionDto>
    {
        private readonly IWriteRepository<ContractCollectionDistribution> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractCollect_DistributeCommandHandler(IWriteRepository<ContractCollectionDistribution> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }


        async Task<ContractCollectionDistributionDto> IRequestHandler<CreateContractCollect_DistributeCommand, ContractCollectionDistributionDto>.Handle(CreateContractCollect_DistributeCommand request, CancellationToken cancellationToken)
        {
            var contractCollect_Distribute = _mapper.Map<ContractCollectionDistribution>(request);
            await _writeRepository.AddAsync(contractCollect_Distribute);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            var dto = _mapper.Map<ContractCollectionDistributionDto>(contractCollect_Distribute);
            return dto;
        }
    }
}
