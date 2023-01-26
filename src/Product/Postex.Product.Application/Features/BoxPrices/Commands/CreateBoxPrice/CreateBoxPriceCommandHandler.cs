using AutoMapper;
using MediatR;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.BoxPrices.Commands.CreateBoxPrice
{
    public class CreateBoxPriceCommandHandler : IRequestHandler<CreateBoxPriceCommand>
    {
        private readonly IWriteRepository<BoxSizePrice> _boxPriceWriteRepository;
        private readonly IMapper _mapper;

        public CreateBoxPriceCommandHandler(IWriteRepository<BoxSizePrice> boxPriceWriteRepository, IMapper mapper)
        {
            _boxPriceWriteRepository = boxPriceWriteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBoxPriceCommand request, CancellationToken cancellationToken)
        {
            var boxPrice = _mapper.Map<BoxSizePrice>(request);
            await _boxPriceWriteRepository.AddAsync(boxPrice);
            await _boxPriceWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
