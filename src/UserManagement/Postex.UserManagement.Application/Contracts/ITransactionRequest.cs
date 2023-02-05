using MediatR;

namespace Postex.UserManagement.Application.Contracts
{
    public class ITransactionRequest<TResponse> : IRequest<TResponse>
    {
    }
    public interface ITransactionRequest : IRequest
    {
    }
}
