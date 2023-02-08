using MediatR;
using Postex.Product.Infrastructure;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Paginations;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain;

namespace Pouya.Application.Features.Users.Queries;

public class GetUsersQuery : PaginationParameters, IRequest<PagedList<UserDto>>
{
    public string? SearchKey { get; set; }
    public class Handler : IRequestHandler<GetUsersQuery, PagedList<UserDto>>
    {
        private readonly IReadRepository<User> _readRepository;
        public Handler(IReadRepository<User> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<PagedList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _readRepository.TableNoTracking;
            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                users = users.Where(x => x.UserName.Contains(request.SearchKey));
            }

            return await users.Select(x => new UserDto
            {
                Id = x.Id,
                UserName = x.UserName,
                IsActive = x.IsActive,
            }).OrderByDescending(x => x.Id)
            .ToPagedListAsync(request.PageIndex, request.PageSize);
        }
    }
}
