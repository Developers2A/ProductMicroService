using AutoMapper;
using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Locations;

namespace Product.Application.Features.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand>
    {
        private readonly IWriteRepository<City> _cityWriteRepository;
        private readonly IReadRepository<City> _cityReadRepository;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(IWriteRepository<City> cityWriteRepository, IReadRepository<City> cityReadRepository, IMapper mapper)
        {
            _cityWriteRepository = cityWriteRepository;
            _cityReadRepository = cityReadRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            City city = await _cityReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (city == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            var updateCity = _mapper.Map(request, city);
            await _cityWriteRepository.UpdateAsync(updateCity);
            await _cityWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
