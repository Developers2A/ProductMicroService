using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Commands.Create
{
    public class CreateCustomerInvoiceInfoCommandHandler : IRequestHandler<CreateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>
    {
        private readonly IWriteRepository<CustomerInvoiceInfo> _writeRepository;
        private readonly IMapper _mapper;

        public CreateCustomerInvoiceInfoCommandHandler(IWriteRepository<CustomerInvoiceInfo> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        async Task<CustomerInvoiceInfo> IRequestHandler<CreateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>.Handle(CreateCustomerInvoiceInfoCommand request, CancellationToken cancellationToken)
        {
            var customerInvoiceInfo = _mapper.Map<CustomerInvoiceInfo>(request);
            await _writeRepository.AddAsync(customerInvoiceInfo, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return customerInvoiceInfo;
        }
    }
}
