using Couriers.Framwork.Api;

namespace Postex.SharedKernel.Exceptions
{
    public class UnauthorizeException : AppException
    {
        public UnauthorizeException(string message) : base(ApiResultStatusCode.UnAuthorized, message, System.Net.HttpStatusCode.Unauthorized)
        {
        }
    }
}
