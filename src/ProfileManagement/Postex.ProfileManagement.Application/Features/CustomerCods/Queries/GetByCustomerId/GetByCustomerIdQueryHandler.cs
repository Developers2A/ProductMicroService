using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.ProfileManagement.Application.Dtos;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.CustomerCods.Queries
{
    public class GetByCustomerIdQueryHandler : IRequestHandler<GetByCustomerIdQuery, CustomerCodDto>
    {
        private readonly IReadRepository<CustomerCod> _readRepository;
        private readonly IMapper _mapper;

        public GetByCustomerIdQueryHandler(IReadRepository<CustomerCod> readRepository,IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mapper = mapper;
        }
        public async Task<CustomerCodDto> Handle(GetByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customerCod = await _readRepository.Table
                .Where(c=> c.Id == request.CustomerId)                
                .FirstOrDefaultAsync(cancellationToken);
            var customerCodDto = _mapper.Map<CustomerCodDto>(customerCod);
            return customerCodDto;
        }
    }
   
}
