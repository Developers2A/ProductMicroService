using AutoMapper;
using MediatR;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.BoxTypes.Commands.CreateBoxType
{
    public class CreateBoxTypeCommandHandler : IRequestHandler<CreateBoxTypeCommand>
    {
        private readonly IWriteRepository<BoxType> _boxTypeWriteRepository;
        private readonly IMapper _mapper;

        public CreateBoxTypeCommandHandler(IWriteRepository<BoxType> boxTypeeWriteRepository, IMapper mapper)
        {
            _boxTypeWriteRepository = boxTypeeWriteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBoxTypeCommand request, CancellationToken cancellationToken)
        {
            var boxType = _mapper.Map<BoxType>(request);
            await _boxTypeWriteRepository.AddAsync(boxType);
            await _boxTypeWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
