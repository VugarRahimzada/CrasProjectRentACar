using CoreLayer.Results.Abstract;
using System.Net;

namespace CoreLayer.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool issuccess, HttpStatusCode statuscode) : base(issuccess, statuscode)
        {
            Data = data;
        }

        public DataResult(T data,bool issuccess, HttpStatusCode statuscode, string message) : base(issuccess, statuscode, message)
        {
            Data = data;
        }

        public T Data {  get; set; }
    }
}
