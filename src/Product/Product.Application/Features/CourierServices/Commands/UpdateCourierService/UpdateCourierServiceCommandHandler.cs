using AutoMapper;
using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServices.Commands.UpdateCourierService
{
    public class UpdateCourierServiceCommandHandler : IRequestHandler<UpdateCourierServiceCommand>
    {
        private readonly IWriteRepository<CourierService> _couierWriteRepository;
        private readonly IReadRepository<CourierService> _courierReadRepository;
        private readonly IMapper _mapper;

        public UpdateCourierServiceCommandHandler(IWriteRepository<CourierService> couierWriteRepository, IReadRepository<CourierService> courierReadRepository, IMapper mapper)
        {
            _couierWriteRepository = couierWriteRepository ?? throw new ArgumentNullException(nameof(couierWriteRepository));
            _courierReadRepository = courierReadRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourierServiceCommand request, CancellationToken cancellationToken)
        {
            CourierService courier = await _courierReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courier == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            var newCourier = _mapper.Map(request, courier);
            await _couierWriteRepository.UpdateAsync(newCourier);
            await _couierWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
