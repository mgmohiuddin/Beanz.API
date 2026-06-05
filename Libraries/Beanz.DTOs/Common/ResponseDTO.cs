using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.DTOs.Common
{
    public class ResponseDTO<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ErrorCode { get; set; } = string.Empty;
        public T? Data { get; set; }
        public int StatusCode { get; set; }

        public object? Errors { get; set; }
        public static ResponseDTO<T> Ok(T data, string message = "Success", int statusCode = 200)
            => new() { Success = true, Message = message, Data = data, StatusCode = statusCode };

        //public static ResponseDTO<T> Fail(string message, string errorCode = "", int statusCode = 400)
        //    => new() { Success = false, Message = message, ErrorCode = errorCode, StatusCode = statusCode };

        public static ResponseDTO<T> Fail(string message, string code, int status, object? errors = null)
        => new()
        {
            Success = false,
            Message = message,
            ErrorCode = code,
            StatusCode = status,
            Errors = errors
        };

    }
}
