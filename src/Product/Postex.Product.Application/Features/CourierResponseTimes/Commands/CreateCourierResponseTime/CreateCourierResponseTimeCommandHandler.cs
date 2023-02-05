using AutoMapper;
using MediatR;
using Postex.Product.Domain.Settings;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierResponseTimes.Commands.CreateCourierResponseTime;

public class CreateCourierResponseTimeCommandHandler : IRequestHandler<CreateCourierResponseTimeCommand>
{
    private readonly IWriteRepository<CourierResponseTime> _responseTimeWriteRepository;
    private readonly IMapper _mapper;

    public CreateCourierResponseTimeCommandHandler(IWriteRepository<CourierResponseTime> responseTimeWriteRepository, IMapper mapper)
    {
        _responseTimeWriteRepository = responseTimeWriteRepository ?? throw new ArgumentNullException(nameof(responseTimeWriteRepository));
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateCourierResponseTimeCommand request, CancellationToken cancellationToken)
    {
        var courierResponseTime = _mapper.Map<CourierResponseTime>(request);

        await _responseTimeWriteRepository.AddAsync(courierResponseTime);
        await _responseTimeWriteRepository.SaveChangeAsync();
        return Unit.Value;
    }
}
