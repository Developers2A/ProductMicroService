using AutoMapper;
using MediatR;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Create
{
    public class CreateCustomerCodCommandHandler : IRequestHandler<CreateCustomerCodCommand, CustomerCod>
    {
        private readonly IWriteRepository<CustomerCod> _writeRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCodCommandHandler(IWriteRepository<CustomerCod> writeRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._mapper = mapper;
        }       

      async  Task<CustomerCod> IRequestHandler<CreateCustomerCodCommand, CustomerCod>.Handle(CreateCustomerCodCommand request, CancellationToken cancellationToken)
        {
            var customerCod = _mapper.Map<CustomerCod>(request);
            await _writeRepository.AddAsync(customerCod, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return customerCod;
        }
    }
}
