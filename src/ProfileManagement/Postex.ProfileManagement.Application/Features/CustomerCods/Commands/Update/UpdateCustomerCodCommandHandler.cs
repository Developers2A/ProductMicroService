using AutoMapper;
using MediatR;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Update
{
    public class UpdateCustomerCodCommandHandler : IRequestHandler<UpdateCustomerCodCommand, CustomerCod>
    {
        private readonly IWriteRepository<CustomerCod> _writeRepository;
        private readonly IReadRepository<CustomerCod> _readRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCodCommandHandler(IWriteRepository<CustomerCod> writeRepository,IReadRepository<CustomerCod> readRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._readRepository = readRepository;
            this._mapper = mapper;
        }       

      async  Task<CustomerCod> IRequestHandler<UpdateCustomerCodCommand, CustomerCod>.Handle(UpdateCustomerCodCommand request, CancellationToken cancellationToken)
        {
            CustomerCod customerCod = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (customerCod == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            customerCod = _mapper.Map<CustomerCod>(request);

            await _writeRepository.AddAsync(customerCod, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return customerCod;
        }
    }
}
