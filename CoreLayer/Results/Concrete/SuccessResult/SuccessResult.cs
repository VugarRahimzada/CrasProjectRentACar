using CoreLayer.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Results.Concrete.SuccessResult
{
    public class SuccessResult : Result
    {
        public SuccessResult(HttpStatusCode statuscode) : base(true, statuscode)
        {
        }

        public SuccessResult(HttpStatusCode statuscode, string message) : base(true, statuscode, message)
        {
        }
    }
}
