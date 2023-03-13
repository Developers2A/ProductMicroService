using MediatR;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Provinces.Commands.CreateProvince
{
    public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand>
    {
        private readonly IWriteRepository<Province> _stateWriteRepository;

        public CreateProvinceCommandHandler(IWriteRepository<Province> stateWriteRepository)
        {
            _stateWriteRepository = stateWriteRepository;
        }

        public async Task<Unit> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
        {
            var state = new Province()
            {
                Name = request.Name,
                Code = request.Code,
                EnglishName = request.EnglishName
            };

            await _stateWriteRepository.AddAsync(state);
            await _stateWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
