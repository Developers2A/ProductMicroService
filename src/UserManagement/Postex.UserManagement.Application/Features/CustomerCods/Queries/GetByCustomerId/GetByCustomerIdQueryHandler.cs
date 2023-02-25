using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Customers;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.CustomerCods.Queries.GetByCustomerId
{
    public class GetByCustomerIdQueryHandler : IRequestHandler<GetByCustomerIdQuery, CustomerCodDto>
    {
        private readonly IReadRepository<CustomerCod> _readRepository;
        private readonly IMapper _mapper;

        public GetByCustomerIdQueryHandler(IReadRepository<CustomerCod> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<CustomerCodDto> Handle(GetByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customerCod = await _readRepository.Table
                .Where(c => c.CustomerId == request.CustomerId)
                .FirstOrDefaultAsync(cancellationToken);
            var customerCodDto = _mapper.Map<CustomerCodDto>(customerCod);
            return customerCodDto;
        }
    }

}
