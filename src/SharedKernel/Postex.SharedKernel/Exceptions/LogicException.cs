using Couriers.Framwork.Api;

namespace Postex.SharedKernel.Exceptions
{
    public class LogicException : AppException
    {
        public LogicException()
            : base(ApiResultStatusCode.LogicError)
        {
        }

        public LogicException(string message)
            : base(ApiResultStatusCode.LogicError, message, System.Net.HttpStatusCode.InternalServerError)
        {
        }

        public LogicException(object additionalData)
            : base(ApiResultStatusCode.LogicError, additionalData)
        {
        }

        public LogicException(string message, object additionalData)
            : base(ApiResultStatusCode.LogicError, message, additionalData)
        {
        }

        public LogicException(string message, Exception exception)
            : base(ApiResultStatusCode.LogicError, message, exception)
        {
        }

        public LogicException(string message, Exception exception, object additionalData)
            : base(ApiResultStatusCode.LogicError, message, exception, additionalData)
        {
        }
    }
}
