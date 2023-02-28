using MediatR;
using Postex.Product.Domain.Common;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostexInsurances.Commands.UpdatePostexInsurance
{
    public class UpdatePostexInsuranceCommandHandler : IRequestHandler<UpdatePostexInsuranceCommand>
    {
        private readonly IWriteRepository<PostexInsurance> _courierInsuranceWriteRepository;
        private readonly IReadRepository<PostexInsurance> _courierInsuranceReadRepository;

        public UpdatePostexInsuranceCommandHandler(
            IWriteRepository<PostexInsurance> courierInsuranceWriteRepository,
                IReadRepository<PostexInsurance> courierInsuranceReadRepository)
        {
            _courierInsuranceWriteRepository = courierInsuranceWriteRepository;
            _courierInsuranceReadRepository = courierInsuranceReadRepository;
        }

        public async Task<Unit> Handle(UpdatePostexInsuranceCommand request, CancellationToken cancellationToken)
        {
            PostexInsurance courierInsurance = await _courierInsuranceReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (courierInsurance == null)
                throw new AppException("اطلاعات یافت نشد");

            courierInsurance.Name = request.Name;
            await _courierInsuranceWriteRepository.UpdateAsync(courierInsurance);
            await _courierInsuranceWriteRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
