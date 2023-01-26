using AutoMapper;
using MediatR;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCods.Commands.CreateCourierCod
{
    public class CreateCourierCodCommandHandler : IRequestHandler<CreateCourierCodCommand>
    {
        private readonly IWriteRepository<CourierCod> _writeRepository;
        private readonly IMapper _mapper;

        public CreateCourierCodCommandHandler(IWriteRepository<CourierCod> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCourierCodCommand request, CancellationToken cancellationToken)
        {
            var courierCod = _mapper.Map<CourierCod>(request);

            await _writeRepository.AddAsync(courierCod, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
