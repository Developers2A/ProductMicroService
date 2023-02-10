using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.ProfileManagement.Application.Dtos;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Queries
{
    public class GetByCustomerIdQueryHandler : IRequestHandler<GetByCustomerIdQuery, CustomerInvoiceInfoDto>
    {
        private readonly IReadRepository<CustomerInvoiceInfo> _readRepository;
        private readonly IMapper _mapper;

        public GetByCustomerIdQueryHandler(IReadRepository<CustomerInvoiceInfo> readRepository,IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mapper = mapper;
        }
        public async Task<CustomerInvoiceInfoDto> Handle(GetByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customerInvoiceInfo = await _readRepository.Table
                .Where(c=> c.Id == request.CustomerId)                
                .FirstOrDefaultAsync(cancellationToken);
            var customerInvoiceInfoDto = _mapper.Map<CustomerInvoiceInfoDto>(customerInvoiceInfo);
            return customerInvoiceInfoDto;
        }
    }
   
}
