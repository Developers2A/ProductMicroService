using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserInvoiceInfos.Queries.GetByUserId
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, UserInvoiceInfoDto>
    {
        private readonly IReadRepository<UserInvoiceInfo> _readRepository;
        private readonly IMapper _mapper;

        public GetByUserIdQueryHandler(IReadRepository<UserInvoiceInfo> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<UserInvoiceInfoDto> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userInvoiceInfo = await _readRepository.Table
                .Where(c => c.UserId == request.UserId)
                .FirstOrDefaultAsync(cancellationToken);
            var userInvoiceInfoDto = _mapper.Map<UserInvoiceInfoDto>(userInvoiceInfo);
            return userInvoiceInfoDto;
        }
    }

}
