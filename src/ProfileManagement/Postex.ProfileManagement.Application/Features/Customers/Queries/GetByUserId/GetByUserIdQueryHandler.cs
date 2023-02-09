using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.ProfileManagement.Application.Dtos;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.Customers.Queries
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByIdQuery, CustomerDto>
    {
        private readonly IReadRepository<Customer> _readRepository;
        private readonly IMapper _mapper;

        public GetByUserIdQueryHandler(IReadRepository<Customer> readRepository,IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _readRepository.Table
                .Where(c=> c.Id == request.Id)                
                .ToListAsync(cancellationToken);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }
    }
   
}
