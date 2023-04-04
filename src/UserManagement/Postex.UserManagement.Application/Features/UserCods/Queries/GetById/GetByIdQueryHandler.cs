using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserCods.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, UserCodDto>
    {
        private readonly IReadRepository<UserCod> _readRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IReadRepository<UserCod> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<UserCodDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var userCod = await _readRepository.Table
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            var userCodDto = _mapper.Map<UserCodDto>(userCod);
            return userCodDto;
        }
    }

}
