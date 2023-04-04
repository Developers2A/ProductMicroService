using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserInvoiceInfos.Commands.Create
{
    public class CreateUserInvoiceInfoCommandHandler : IRequestHandler<CreateUserInvoiceInfoCommand, UserInvoiceInfo>
    {
        private readonly IWriteRepository<UserInvoiceInfo> _writeRepository;
        private readonly IMapper _mapper;

        public CreateUserInvoiceInfoCommandHandler(IWriteRepository<UserInvoiceInfo> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        async Task<UserInvoiceInfo> IRequestHandler<CreateUserInvoiceInfoCommand, UserInvoiceInfo>.Handle(CreateUserInvoiceInfoCommand request, CancellationToken cancellationToken)
        {
            var userInvoiceInfo = _mapper.Map<UserInvoiceInfo>(request);
            await _writeRepository.AddAsync(userInvoiceInfo, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return userInvoiceInfo;
        }
    }
}
