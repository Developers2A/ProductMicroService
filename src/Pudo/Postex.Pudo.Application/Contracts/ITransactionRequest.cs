using MediatR;

namespace Postex.Pudo.Application.Contracts
{
    public class ITransactionRequest<TResponse> : IRequest<TResponse>
    {
    }
    public interface ITransactionRequest : IRequest
    {
    }
}
