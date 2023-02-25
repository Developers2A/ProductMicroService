using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Customers;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.Customers.Queries.GetByUserId
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, CustomerDto>
    {
        private readonly IReadRepository<Customer> _readRepository;
        private readonly IMapper _mapper;

        public GetByUserIdQueryHandler(IReadRepository<Customer> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _readRepository.Table
                .Where(c => c.UserId == request.UserId)
                .FirstOrDefaultAsync(cancellationToken);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }
    }

}
