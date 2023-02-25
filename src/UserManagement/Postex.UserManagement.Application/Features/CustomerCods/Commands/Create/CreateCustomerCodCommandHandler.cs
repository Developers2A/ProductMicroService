using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.CustomerCods.Commands.Create
{
    public class CreateCustomerCodCommandHandler : IRequestHandler<CreateCustomerCodCommand, CustomerCod>
    {
        private readonly IWriteRepository<CustomerCod> _writeRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCodCommandHandler(IWriteRepository<CustomerCod> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        async Task<CustomerCod> IRequestHandler<CreateCustomerCodCommand, CustomerCod>.Handle(CreateCustomerCodCommand request, CancellationToken cancellationToken)
        {
            var customerCod = _mapper.Map<CustomerCod>(request);
            await _writeRepository.AddAsync(customerCod, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return customerCod;
        }
    }
}
