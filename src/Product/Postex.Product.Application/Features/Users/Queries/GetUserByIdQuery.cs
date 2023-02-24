using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Users;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Users.Queries;

public class GetUserByIdQuery : ITransactionRequest<BaseResponse<UserDto>>
{
    public Guid UserId { get; set; }
}
