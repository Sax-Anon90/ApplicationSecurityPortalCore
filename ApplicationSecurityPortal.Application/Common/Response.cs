using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurityPortal.Application.Common
{
    public class Response<T>
    {
        public Response()
        {

        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionError { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string InnerException { get; set; }
        public List<string> Errors { get; set; }

        public T Data { get; set; }
    }
}
