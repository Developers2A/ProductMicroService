using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Product.Domain.ValueAddedPrices;

namespace Product.Application.Features.BoxPrices.Commands.CreateBoxPrice
{
    public class CreateBoxPriceCommandHandler : IRequestHandler<CreateBoxPriceCommand>
    {
        private readonly IWriteRepository<BoxPrice> _boxPriceWriteRepository;
        private readonly IMapper _mapper;

        public CreateBoxPriceCommandHandler(IWriteRepository<BoxPrice> boxPriceWriteRepository, IMapper mapper)
        {
            _boxPriceWriteRepository = boxPriceWriteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBoxPriceCommand request, CancellationToken cancellationToken)
        {
            var boxPrice = _mapper.Map<BoxPrice>(request);
            await _boxPriceWriteRepository.AddAsync(boxPrice);
            await _boxPriceWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
