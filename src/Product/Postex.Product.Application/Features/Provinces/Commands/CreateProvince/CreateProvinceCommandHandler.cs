using MediatR;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Provinces.Commands.CreateProvince
{
    public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand>
    {
        private readonly IWriteRepository<Province> _provinceWriteRepository;

        public CreateProvinceCommandHandler(IWriteRepository<Province> provinceWriteRepository)
        {
            _provinceWriteRepository = provinceWriteRepository;
        }

        public async Task<Unit> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
        {
            var province = new Province()
            {
                Name = request.Name,
                Code = request.Code,
                EnglishName = request.EnglishName
            };

            await _provinceWriteRepository.AddAsync(province);
            await _provinceWriteRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
