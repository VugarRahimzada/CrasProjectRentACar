using CoreLayer.Results.Abstract;
using System.Net;

namespace CoreLayer.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool issuccess, HttpStatusCode statuscode, string message) 
        {
            IsSuccess = issuccess;
            StatusCode = statuscode;
            Message = message;
        }
        public Result(bool issuccess, HttpStatusCode statuscode)
        {
            IsSuccess = issuccess;
            StatusCode = statuscode;
        }

        public string Message { get; }

        public HttpStatusCode StatusCode { get; }

        public bool IsSuccess { get; }
    }
}
