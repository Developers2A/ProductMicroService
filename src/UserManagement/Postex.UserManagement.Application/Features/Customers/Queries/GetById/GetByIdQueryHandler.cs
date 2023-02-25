using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Customers;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.Customers.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CustomerDto>
    {
        private readonly IReadRepository<Customer> _readRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IReadRepository<Customer> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _readRepository.Table
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }
    }

}
