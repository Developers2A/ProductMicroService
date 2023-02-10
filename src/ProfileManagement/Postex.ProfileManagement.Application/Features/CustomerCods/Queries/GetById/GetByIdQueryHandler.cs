using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.ProfileManagement.Application.Dtos;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.CustomerCods.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CustomerCodDto>
    {
        private readonly IReadRepository<CustomerCod> _readRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IReadRepository<CustomerCod> readRepository,IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mapper = mapper;
        }
        public async Task<CustomerCodDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var customerCod = await _readRepository.Table
                .Where(c=> c.Id == request.Id)                
                .FirstOrDefaultAsync(cancellationToken);
            var customerCodDto = _mapper.Map<CustomerCodDto>(customerCod);
            return customerCodDto;
        }
    }
   
}
