using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IWriteRepository<User> _writeRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IWriteRepository<User> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        async Task<User> IRequestHandler<CreateUserCommand, User>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _writeRepository.AddAsync(user, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return user;
        }
    }
}
