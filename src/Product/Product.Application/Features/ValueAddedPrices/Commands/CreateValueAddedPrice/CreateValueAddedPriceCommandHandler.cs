using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.ValueAddedPrices.Commands.CreateValueAddedPrice
{
    public class CreateValueAddedPriceCommandHandler : IRequestHandler<CreateValueAddedPriceCommand>
    {
        private readonly IWriteRepository<ValueAddedPrice> _boxPriceWriteRepository;
        private readonly IMapper _mapper;

        public CreateValueAddedPriceCommandHandler(IWriteRepository<ValueAddedPrice> boxPriceWriteRepository, IMapper mapper)
        {
            _boxPriceWriteRepository = boxPriceWriteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateValueAddedPriceCommand request, CancellationToken cancellationToken)
        {
            var valueAddedPrice = _mapper.Map<ValueAddedPrice>(request);
            await _boxPriceWriteRepository.AddAsync(valueAddedPrice);
            await _boxPriceWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
