using AutoMapper;
using MediatR;
using Postex.Product.Domain.Common;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostexInsurances.Commands.CreatePostexInsurance
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
