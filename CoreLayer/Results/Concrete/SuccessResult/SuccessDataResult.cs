using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Results.Concrete.SuccessResult
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, HttpStatusCode statuscode) : base(data, true, statuscode)
        {
        }

        public SuccessDataResult(T data, HttpStatusCode statuscode, string message) : base(data, true, statuscode, message)
        {
        }
    }
}
