using AutoMapper;
using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserCods.Commands.Update
{
    public class UpdateUserCodCommandHandler : IRequestHandler<UpdateUserCodCommand, UserCod>
    {
        private readonly IWriteRepository<UserCod> _writeRepository;
        private readonly IReadRepository<UserCod> _readRepository;
        private readonly IMapper _mapper;

        public UpdateUserCodCommandHandler(IWriteRepository<UserCod> writeRepository, IReadRepository<UserCod> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        async Task<UserCod> IRequestHandler<UpdateUserCodCommand, UserCod>.Handle(UpdateUserCodCommand request, CancellationToken cancellationToken)
        {
            UserCod userCod = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (userCod == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            userCod = _mapper.Map<UserCod>(request);

            await _writeRepository.AddAsync(userCod, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return userCod;
        }
    }
}
