using MediatR;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZoneCityMappings.Commands.UpdateCourierZoneCityMapping
{
    public class UpdateCourierZoneCityMappingCommandHandler : IRequestHandler<UpdateCourierZoneCityMappingCommand>
    {
        private readonly IWriteRepository<CourierZoneCityMapping> _courierZoneCityMappingWriteRepository;
        private readonly IReadRepository<CourierZoneCityMapping> _courierZoneCityMappingReadRepository;

        public UpdateCourierZoneCityMappingCommandHandler(
            IWriteRepository<CourierZoneCityMapping> courierZoneCityWriteRepository,
            IReadRepository<CourierZoneCityMapping> courierZoneCityReadRepository)
        {
            _courierZoneCityMappingWriteRepository = courierZoneCityWriteRepository;
            _courierZoneCityMappingReadRepository = courierZoneCityReadRepository;
        }

        public async Task<Unit> Handle(UpdateCourierZoneCityMappingCommand request, CancellationToken cancellationToken)
        {
            CourierZoneCityMapping courierCity = await _courierZoneCityMappingReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierCity == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _courierZoneCityMappingWriteRepository.UpdateAsync(courierCity);
            await _courierZoneCityMappingWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }

}
