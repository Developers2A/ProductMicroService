using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserInvoiceInfos.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, UserInvoiceInfoDto>
    {
        private readonly IReadRepository<UserInvoiceInfo> _readRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IReadRepository<UserInvoiceInfo> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<UserInvoiceInfoDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var userInvoiceInfo = await _readRepository.Table
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            var userInvoiceInfoDto = _mapper.Map<UserInvoiceInfoDto>(userInvoiceInfo);
            return userInvoiceInfoDto;
        }
    }

}
