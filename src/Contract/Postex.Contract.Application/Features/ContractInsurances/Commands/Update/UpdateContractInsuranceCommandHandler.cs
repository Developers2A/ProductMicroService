using AutoMapper;
using MediatR;
using Postex.Contract.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.ContractInsurances.Commands.Update
{
    public class UpdateContractInsuranceCommandHandler : IRequestHandler<UpdateContractInsuranceCommand>
    {
        private readonly IWriteRepository<ContractInsurance> _writeRepository;
        private readonly IReadRepository<ContractInsurance> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractInsuranceCommandHandler(IWriteRepository<ContractInsurance> writeRepository, IReadRepository<ContractInsurance> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateContractInsuranceCommand request, CancellationToken cancellationToken)
        {
            ContractInsurance contractInsurance = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractInsurance == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractInsurance.FromValue = request.FromValue;
            contractInsurance.ToValue = request.ToValue;
            contractInsurance.FixedValue = request.FixedValue;
            contractInsurance.FixedPercent = request.FixedPercent;
            contractInsurance.Description = request.Description;
            contractInsurance.IsActice = request.IsActice;

            await _writeRepository.UpdateAsync(contractInsurance);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
