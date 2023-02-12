using MediatR;

namespace Postex.ProfileManagement.Application.Contracts
{
    public class ITransactionRequest<TRequest>:IRequest<TRequest>
    {
    }
    public interface ITransactionRequest : IRequest
    { 
    }
}
