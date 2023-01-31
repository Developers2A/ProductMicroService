using AutoMapper;
using MediatR;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Cities.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand>
    {
        private readonly IWriteRepository<City> _cityWriteRepository;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(IWriteRepository<City> cityWriteRepository, IMapper mapper)
        {
            _cityWriteRepository = cityWriteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = _mapper.Map<City>(request);

            await _cityWriteRepository.AddAsync(city, cancellationToken);
            await _cityWriteRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
