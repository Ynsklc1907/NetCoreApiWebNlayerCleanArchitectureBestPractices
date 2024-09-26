using System.Net;
using System.Text.Json.Serialization;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }

        public List<string>? ErrorMessage { get; set; }
        [JsonIgnore] public bool IsSuccess => ErrorMessage == null && ErrorMessage?.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }
        [JsonIgnore] public string? UrlAsCreated { get; set; }
        //Static Factory Method
        public static ServiceResult<T> Success(T data,HttpStatusCode Status=HttpStatusCode.OK) 
        {
            return new ServiceResult<T>() 
            { 
                Data = data,
                Status = Status
            };
        }
        public static ServiceResult<T> SuccessAsCreated(T data, string urlAsCreated)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = HttpStatusCode.Created,
                UrlAsCreated= urlAsCreated
            };
        }

        public static ServiceResult<T> Fail(List<string> errorMessage, HttpStatusCode Status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = errorMessage,
                Status = Status
            };
        }
        public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode Status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessage = [errorMessage],
                Status = Status
            };
        }


    }


    public class ServiceResult
    {

        public List<string>? ErrorMessage { get; set; }

        [JsonIgnore] public bool IsSuccess => ErrorMessage == null && ErrorMessage?.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }
        //Static Factory Method
        public static ServiceResult Success( HttpStatusCode Status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                Status = Status
            };
        }

        public static ServiceResult Fail(List<string> errorMessage, HttpStatusCode Status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = errorMessage,
                Status = Status
            };
        }
        public static ServiceResult Fail(string errorMessage, HttpStatusCode Status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessage = [errorMessage],
                Status = Status
            };
        }


    }



}
