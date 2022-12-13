using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.PostexInsurances.Commands.CreatePostexInsurance
{
    public class CreatePostexInsuranceCommandHandler : IRequestHandler<CreatePostexInsuranceCommand>
    {
        private readonly IWriteRepository<PostexInsurance> _courierInsuranceWriteRepository;
        private readonly IMapper _mapper;

        public CreatePostexInsuranceCommandHandler(IWriteRepository<PostexInsurance> courierInsuranceWriteRepository, IMapper mapper)
        {
            _courierInsuranceWriteRepository = courierInsuranceWriteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePostexInsuranceCommand request, CancellationToken cancellationToken)
        {
            var courierInsurance = _mapper.Map<PostexInsurance>(request);

            await _courierInsuranceWriteRepository.AddAsync(courierInsurance, cancellationToken);
            await _courierInsuranceWriteRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
