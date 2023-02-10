using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.ProfileManagement.Application.Dtos;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.Customers.Queries
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, CustomerDto>
    {
        private readonly IReadRepository<Customer> _readRepository;
        private readonly IMapper _mapper;

        public GetByUserIdQueryHandler(IReadRepository<Customer> readRepository,IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _readRepository.Table
                .Where(c=> c.UserId == request.UserId)                
                .FirstOrDefaultAsync(cancellationToken);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }
    }
   
}
