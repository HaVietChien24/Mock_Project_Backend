using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Repository.ApiResult
{
    public class APIResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }


        public APIResult(T data, string message = "")
        {
            Success = true;
            Data = data;
            Message = message;
        }


        public APIResult(string message)
        {
            Success = false;
            Message = message;
        }


        public static APIResult<T> SuccessResult(T data, string message = "") => new APIResult<T>(data, message);
        public static APIResult<T> FailureResult(string message) => new APIResult<T>(message);
    }
}
