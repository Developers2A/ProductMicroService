using AutoMapper;
using MediatR;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Update
{
    public class UpdateCustomerInvoiceInfoCommandHandler : IRequestHandler<UpdateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>
    {
        private readonly IWriteRepository<CustomerInvoiceInfo> _writeRepository;
        private readonly IReadRepository<CustomerInvoiceInfo> _readRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerInvoiceInfoCommandHandler(IWriteRepository<CustomerInvoiceInfo> writeRepository,IReadRepository<CustomerInvoiceInfo> readRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._readRepository = readRepository;
            this._mapper = mapper;
        }       

      async  Task<CustomerInvoiceInfo> IRequestHandler<UpdateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>.Handle(UpdateCustomerInvoiceInfoCommand request, CancellationToken cancellationToken)
        {
            CustomerInvoiceInfo customerInvoiceInfo = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (customerInvoiceInfo == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            customerInvoiceInfo = _mapper.Map<CustomerInvoiceInfo>(request);
            
            await _writeRepository.AddAsync(customerInvoiceInfo, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return customerInvoiceInfo;
        }
    }
}
