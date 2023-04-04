using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserCods.Queries.GetByUserId
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, UserCodDto>
    {
        private readonly IReadRepository<UserCod> _readRepository;
        private readonly IMapper _mapper;

        public GetByUserIdQueryHandler(IReadRepository<UserCod> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<UserCodDto> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userCod = await _readRepository.Table
                .Where(c => c.UserId == request.UserId)
                .FirstOrDefaultAsync(cancellationToken);
            var userCodDto = _mapper.Map<UserCodDto>(userCod);
            return userCodDto;
        }
    }

}
