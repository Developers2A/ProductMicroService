using AutoMapper;
using MediatR;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Create
{
    public class CreateCustomerInvoiceInfoCommandHandler : IRequestHandler<CreateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>
    {
        private readonly IWriteRepository<CustomerInvoiceInfo> _writeRepository;
        private readonly IMapper _mapper;

        public CreateCustomerInvoiceInfoCommandHandler(IWriteRepository<CustomerInvoiceInfo> writeRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._mapper = mapper;
        }       

      async  Task<CustomerInvoiceInfo> IRequestHandler<CreateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>.Handle(CreateCustomerInvoiceInfoCommand request, CancellationToken cancellationToken)
        {
            var customerInvoiceInfo = _mapper.Map<CustomerInvoiceInfo>(request);
            await _writeRepository.AddAsync(customerInvoiceInfo, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return customerInvoiceInfo;
        }
    }
}
