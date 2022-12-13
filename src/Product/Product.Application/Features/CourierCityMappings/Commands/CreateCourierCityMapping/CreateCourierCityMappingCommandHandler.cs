using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierCityMappings.Commands.CreateCourierCityMapping
{
    public class CreateCourierCityMappingCommandHandler : IRequestHandler<CreateCourierCityMappingCommand>
    {
        private readonly IWriteRepository<CourierCityMapping> _courierCityWriteRepository;
        private readonly IMapper _mapper;

        public CreateCourierCityMappingCommandHandler(IWriteRepository<CourierCityMapping> courierCityWriteRepository, IMapper mapper)
        {
            _courierCityWriteRepository = courierCityWriteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCourierCityMappingCommand request, CancellationToken cancellationToken)
        {
            var courierCity = _mapper.Map<CourierCityMapping>(request);

            await _courierCityWriteRepository.AddAsync(courierCity);
            await _courierCityWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
