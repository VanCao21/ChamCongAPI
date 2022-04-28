using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChamCong2.API.Models
{
    public class Response
    {
        public Response(HttpStatusCode code, string message)
        {
            Code = code;
            Message = message;
        }
        public Response(string message)
        {
            Message = message;
        }
        public Response()
        {
        }
        public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;
        public string Message { get; set; } = "Success";
        public bool IsSuccess
        {
            get { return Code == HttpStatusCode.OK; }
        }
        public class APIReponsitory
        {
            public APIReponsitory() { }
            public APIReponsitory(bool success, string message)
            {
                Success = success;
                Message = message;
            }
            public APIReponsitory(bool success, string message, string data)
            {
                Success = success;
                Message = message;
                Data = data;
            }
            public Boolean Success { get; set; }
            public string Message { get; set; }
            public string Data { get; set; }
        }
    }
}
