using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Application.ReusableClasses
{
    public class ResponseWithApiStatusCode<T>
    {
        public ResponseWithApiStatusCode()
        {

        }

        public int StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionError { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string InnerException { get; set; }

        public T Data { get; set; }
    }
}
