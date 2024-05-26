using System.Net;

namespace CoreLayer.Results.Concrete.ErrorResult
{
    public class ErrorResult : Result
    {
        public ErrorResult(HttpStatusCode statuscode) : base(false, statuscode)
        {
        }

        public ErrorResult(HttpStatusCode statuscode, string message) : base(false, statuscode, message)
        {
        }
    }
}
