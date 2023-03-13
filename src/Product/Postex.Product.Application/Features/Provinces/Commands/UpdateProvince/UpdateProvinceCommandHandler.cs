using MediatR;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Provinces.Commands.UpdateProvince
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand>
    {
        private readonly IWriteRepository<Province> _stateWriteRepository;
        private readonly IReadRepository<Province> _stateReadRepository;

        public UpdateProvinceCommandHandler(
            IWriteRepository<Province> stateWriteRepository,
            IReadRepository<Province> stateReadRepository)
        {
            _stateWriteRepository = stateWriteRepository;
            _stateReadRepository = stateReadRepository;
        }

        public async Task<Unit> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
        {
            Province state = await _stateReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (state == null)
                throw new AppException("اطلاعات یافت نشد");

            state.Name = request.Name;
            state.Code = request.Code;
            state.EnglishName = request.EnglishName;
            await _stateWriteRepository.UpdateAsync(state);
            await _stateWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
