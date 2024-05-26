using System.Net;

namespace CoreLayer.Results.Concrete.ErrorResult
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, HttpStatusCode statuscode) : base(data, false, statuscode)
        {
        }

        public ErrorDataResult(T data, HttpStatusCode statuscode, string message) : base(data, false, statuscode, message)
        {
        }
    }
}
