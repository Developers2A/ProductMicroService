using MediatR;

namespace Postex.Notification.Application.Contracts
{
    public class ITransactionRequest<TResponse> : IRequest<TResponse>
    {
    }
    public interface ITransactionRequest : IRequest
    {
    }
}
