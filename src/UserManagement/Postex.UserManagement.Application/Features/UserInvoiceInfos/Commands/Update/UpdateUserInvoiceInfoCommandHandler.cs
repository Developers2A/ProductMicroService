using AutoMapper;
using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserInvoiceInfos.Commands.Update
{
    public class UpdateUserInvoiceInfoCommandHandler : IRequestHandler<UpdateUserInvoiceInfoCommand, UserInvoiceInfo>
    {
        private readonly IWriteRepository<UserInvoiceInfo> _writeRepository;
        private readonly IReadRepository<UserInvoiceInfo> _readRepository;
        private readonly IMapper _mapper;

        public UpdateUserInvoiceInfoCommandHandler(IWriteRepository<UserInvoiceInfo> writeRepository, IReadRepository<UserInvoiceInfo> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        async Task<UserInvoiceInfo> IRequestHandler<UpdateUserInvoiceInfoCommand, UserInvoiceInfo>.Handle(UpdateUserInvoiceInfoCommand request, CancellationToken cancellationToken)
        {
            UserInvoiceInfo userInvoiceInfo = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (userInvoiceInfo == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            userInvoiceInfo = _mapper.Map<UserInvoiceInfo>(request);

            await _writeRepository.AddAsync(userInvoiceInfo, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return userInvoiceInfo;
        }
    }
}
