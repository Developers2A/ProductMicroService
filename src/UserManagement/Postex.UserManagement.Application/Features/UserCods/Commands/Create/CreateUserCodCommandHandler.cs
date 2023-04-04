using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserCods.Commands.Create
{
    public class CreateUserCodCommandHandler : IRequestHandler<CreateUserCodCommand, UserCod>
    {
        private readonly IWriteRepository<UserCod> _writeRepository;
        private readonly IMapper _mapper;

        public CreateUserCodCommandHandler(IWriteRepository<UserCod> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        async Task<UserCod> IRequestHandler<CreateUserCodCommand, UserCod>.Handle(CreateUserCodCommand request, CancellationToken cancellationToken)
        {
            var userCod = _mapper.Map<UserCod>(request);
            await _writeRepository.AddAsync(userCod, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return userCod;
        }
    }
}
