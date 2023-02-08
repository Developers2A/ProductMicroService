using MediatR;
using Microsoft.Extensions.Configuration;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain;

namespace Pouya.Application.Features.Users.Queries;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public long Id { get; set; }

    public class Handler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IReadRepository<User> _context;
        private readonly IConfiguration _configuration;
        private readonly string _domain;
        public Handler(IReadRepository<User> context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _domain = _configuration["SiteSettings:Domain"];
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _context.TableNoTracking.FirstOrDefault(x => x.Id == request.Id);
            return new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                IsActive = user.IsActive,
            };
        }
    }
}
