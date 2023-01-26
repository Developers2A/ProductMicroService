using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCityMappings.Commands.UpdateCourierMapping
{
    public class UpdateCourierCityMappingCommandHandler : IRequestHandler<UpdateCourierCityMappingCommand>
    {
        private readonly IWriteRepository<CourierCityMapping> _courierCityWriteRepository;
        private readonly IReadRepository<CourierCityMapping> _courierCityReadRepository;

        public UpdateCourierCityMappingCommandHandler(
            IWriteRepository<CourierCityMapping> courierCityWriteRepository,
            IReadRepository<CourierCityMapping> courierCityReadRepository)
        {
            _courierCityWriteRepository = courierCityWriteRepository;
            _courierCityReadRepository = courierCityReadRepository;
        }

        public async Task<Unit> Handle(UpdateCourierCityMappingCommand request, CancellationToken cancellationToken)
        {
            CourierCityMapping courierCity = await _courierCityReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierCity == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _courierCityWriteRepository.UpdateAsync(courierCity);
            await _courierCityWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }

}
