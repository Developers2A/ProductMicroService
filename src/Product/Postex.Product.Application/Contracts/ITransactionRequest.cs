using MediatR;

namespace Postex.Product.Application.Contracts
{
    public class ITransactionRequest<TResponse> : IRequest<TResponse>
    {
    }
    public interface ITransactionRequest : IRequest
    {
    }
}
