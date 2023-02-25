using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Customers;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Customers.Queries;

public class GetCustomerByUserIdQuery : ITransactionRequest<BaseResponse<CustomerDto>>
{
    public Guid UserId { get; set; }
}
