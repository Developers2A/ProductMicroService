using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Customers;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CustomerInvoiceInfoDto>
    {
        private readonly IReadRepository<CustomerInvoiceInfo> _readRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IReadRepository<CustomerInvoiceInfo> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<CustomerInvoiceInfoDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var customerInvoiceInfo = await _readRepository.Table
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            var customerInvoiceInfoDto = _mapper.Map<CustomerInvoiceInfoDto>(customerInvoiceInfo);
            return customerInvoiceInfoDto;
        }
    }

}
