using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZoneCityMappings.Commands.CreateCourierZoneCityMapping
{
    public class CreateCourierZoneCityMappingCommandHandler : IRequestHandler<CreateCourierZoneCityMappingCommand>
    {
        private readonly IWriteRepository<CourierZoneCityMapping> _courierZoneCityWriteRepository;
        private readonly IMapper _mapper;

        public CreateCourierZoneCityMappingCommandHandler(IWriteRepository<CourierZoneCityMapping> courierCityWriteRepository, IMapper mapper)
        {
            _courierZoneCityWriteRepository = courierCityWriteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCourierZoneCityMappingCommand request, CancellationToken cancellationToken)
        {
            var courierCity = _mapper.Map<CourierZoneCityMapping>(request);

            await _courierZoneCityWriteRepository.AddAsync(courierCity);
            await _courierZoneCityWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
