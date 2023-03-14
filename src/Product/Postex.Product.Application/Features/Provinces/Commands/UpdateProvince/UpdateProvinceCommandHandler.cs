using MediatR;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Provinces.Commands.UpdateProvince
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand>
    {
        private readonly IWriteRepository<Province> _provinceWriteRepository;
        private readonly IReadRepository<Province> _provinceReadRepository;

        public UpdateProvinceCommandHandler(
            IWriteRepository<Province> provinceWriteRepository,
            IReadRepository<Province> provinceReadRepository)
        {
            _provinceWriteRepository = provinceWriteRepository;
            _provinceReadRepository = provinceReadRepository;
        }

        public async Task<Unit> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
        {
            Province province = await _provinceReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (province == null)
                throw new AppException("اطلاعات یافت نشد");

            province.Name = request.Name;
            province.Code = request.Code;
            province.EnglishName = request.EnglishName;
            await _provinceWriteRepository.UpdateAsync(province);
            await _provinceWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
