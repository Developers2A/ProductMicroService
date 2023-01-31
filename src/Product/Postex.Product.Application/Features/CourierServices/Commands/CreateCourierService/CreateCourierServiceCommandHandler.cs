using AutoMapper;
using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierServices.Commands.CreateCourierService
{
    public class CreateCourierServiceCommandHandler : IRequestHandler<CreateCourierServiceCommand>
    {
        private readonly IWriteRepository<CourierService> _courierServiceWriteRepository;
        private readonly IMapper _mapper;

        public CreateCourierServiceCommandHandler(IWriteRepository<CourierService> courierServiceWriteRepository, IMapper mapper)
        {
            _courierServiceWriteRepository = courierServiceWriteRepository ?? throw new ArgumentNullException(nameof(courierServiceWriteRepository));
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCourierServiceCommand request, CancellationToken cancellationToken)
        {
            var courier = _mapper.Map<CourierService>(request);

            await _courierServiceWriteRepository.AddAsync(courier);
            await _courierServiceWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
