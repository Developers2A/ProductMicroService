using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.Couriers.Commands.CreateCourier
{
    public class CreateCourierCommandHandler : IRequestHandler<CreateCourierCommand>
    {
        private readonly IWriteRepository<Courier> _courierWriteRepository;
        private readonly IMapper _mapper;

        public CreateCourierCommandHandler(IWriteRepository<Courier> courierWriteRepository, IMapper mapper)
        {
            _courierWriteRepository = courierWriteRepository ?? throw new ArgumentNullException(nameof(courierWriteRepository));
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCourierCommand request, CancellationToken cancellationToken)
        {
            var courier = _mapper.Map<Courier>(request);

            await _courierWriteRepository.AddAsync(courier);
            await _courierWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
