using System.Net;

namespace TetronJob.Exceptions
{

    public class AppException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public object AdditionalData { get; set; }


        public AppException(string message, HttpStatusCode httpStatusCode, Exception exception, object additionalData)
            : base(message, exception)
        {

            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
        }
    }
}
