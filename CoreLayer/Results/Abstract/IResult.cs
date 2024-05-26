using System.Net;

namespace CoreLayer.Results.Abstract
{
    public interface IResult
    {
        string Message { get; }
        HttpStatusCode StatusCode { get; }
        bool IsSuccess { get; }
    }
}
