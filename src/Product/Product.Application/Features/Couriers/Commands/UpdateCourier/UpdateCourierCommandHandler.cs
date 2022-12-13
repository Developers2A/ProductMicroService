using AutoMapper;
using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.Couriers.Commands.UpdateCourier
{
    public class UpdateCourierCommandHandler : IRequestHandler<UpdateCourierCommand>
    {
        private readonly IWriteRepository<Courier> _couierWriteRepository;
        private readonly IReadRepository<Courier> _courierReadRepository;
        private readonly IMapper _mapper;

        public UpdateCourierCommandHandler(IWriteRepository<Courier> couierWriteRepository, IReadRepository<Courier> courierReadRepository, IMapper mapper)
        {
            _couierWriteRepository = couierWriteRepository ?? throw new ArgumentNullException(nameof(couierWriteRepository));
            _courierReadRepository = courierReadRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourierCommand request, CancellationToken cancellationToken)
        {
            Courier courier = await _courierReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courier == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            var newCourier = _mapper.Map(request, courier);
            await _couierWriteRepository.UpdateAsync(newCourier);
            await _couierWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
