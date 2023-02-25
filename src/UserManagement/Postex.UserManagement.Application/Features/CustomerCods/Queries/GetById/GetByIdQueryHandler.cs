using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Customers;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.CustomerCods.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CustomerCodDto>
    {
        private readonly IReadRepository<CustomerCod> _readRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IReadRepository<CustomerCod> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<CustomerCodDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var customerCod = await _readRepository.Table
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            var customerCodDto = _mapper.Map<CustomerCodDto>(customerCod);
            return customerCodDto;
        }
    }

}
