using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IWriteRepository<User> _writeRepository;
        private readonly IReadRepository<User> _readRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IWriteRepository<User> writeRepository, IReadRepository<User> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        async Task<User> IRequestHandler<UpdateUserCommand, User>.Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _readRepository.Table
                .Where(c => c.Id == request.Id).FirstOrDefaultAsync();

            if (user == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            // user = _mapper.Map<User>(request);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.FatherName = request.FatherName;
            user.Email = request.Email;
            user.Mobile = request.MobileNo;
            user.NationalCode = request.NationalCode;
            user.PostalCode = request.PostalCode;
            user.IsActive = request.IsActive;
            user.IsShahkarValidate = request.IsShahkarValidate;

            await _writeRepository.UpdateAsync(user, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return user;
        }
    }
}
