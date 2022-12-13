using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierInsurances.Commands.CreateCourierInsurance
{
    public class CreateCourierInsuranceCommandHandler : IRequestHandler<CreateCourierInsuranceCommand>
    {
        private readonly IWriteRepository<CourierInsurance> _courierInsuranceWriteRepository;
        private readonly IMapper _mapper;

        public CreateCourierInsuranceCommandHandler(IWriteRepository<CourierInsurance> courierInsuranceWriteRepository, IMapper mapper)
        {
            _courierInsuranceWriteRepository = courierInsuranceWriteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCourierInsuranceCommand request, CancellationToken cancellationToken)
        {
            var courierInsurance = _mapper.Map<CourierInsurance>(request);

            await _courierInsuranceWriteRepository.AddAsync(courierInsurance, cancellationToken);
            await _courierInsuranceWriteRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
