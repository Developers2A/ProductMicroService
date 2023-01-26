using AutoMapper;
using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierLimitValues.Commands.CreateCourierLimitValue
{
    public class CreateCourierLimitValueCommandHandler : IRequestHandler<CreateCourierLimitValueCommand>
    {
        private readonly IWriteRepository<CourierLimitValue> _writeRepository;
        private readonly IMapper _mapper;

        public CreateCourierLimitValueCommandHandler(IWriteRepository<CourierLimitValue> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCourierLimitValueCommand request, CancellationToken cancellationToken)
        {
            var courierLimitValue = _mapper.Map<CourierLimitValue>(request);

            await _writeRepository.AddAsync(courierLimitValue);
            await _writeRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
