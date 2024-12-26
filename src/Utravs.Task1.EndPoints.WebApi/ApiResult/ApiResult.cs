using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utravs.Task1.Domain.Exceptions;
using Utravs.Task1.Domain.ExtenstionMethods;

namespace Utravs.Task1.EndPoints.WebApi.ApiResult
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        [JsonIgnore]
        public CustomApiResultStatusCode StatusCode { get; set; }

        public string Status => StatusCode.ToString();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { set; get; }//=> StatusCode.ToDisplay()

       

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ValidationErrorResult> Errors { set; get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object CreatedObjectResult { set; get; }
        // [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //  public string Message { get; set; }

        public ApiResult(bool isSuccess, CustomApiResultStatusCode statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Description = message ?? statusCode.ToDisplay();
        }
        public ApiResult(bool isSuccess, CustomApiResultStatusCode statusCode, string message = null, object createdObjectResult = null)
        {
            CreatedObjectResult = createdObjectResult;
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Description = message ?? statusCode.ToDisplay();
        }
        #region Implicit Operators
        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(true, CustomApiResultStatusCode.Success, null);
        }

        public static implicit operator ApiResult(BadRequestResult result)
        {
            return new ApiResult(false, CustomApiResultStatusCode.BadRequest, null);
        }

        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            var message = result.Value?.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult(false, CustomApiResultStatusCode.BadRequest, message);
        }

        public static implicit operator ApiResult(ContentResult result)
        {
            return new ApiResult(true, CustomApiResultStatusCode.Success, result.Content);
        }

        public static implicit operator ApiResult(NotFoundResult result)
        {
            return new ApiResult(false, CustomApiResultStatusCode.NotFound, null);
        }


        public static implicit operator ApiResult(CreatedResult result)
        {
            return new ApiResult(true, CustomApiResultStatusCode.Success, null);
        }

        public static implicit operator ApiResult(CreatedAtActionResult result)
        {
            return new ApiResult(true, CustomApiResultStatusCode.Success, null);
        }
        #endregion
    }

    public class ApiResult<TData> : ApiResult
        where TData : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TData Data { get; set; }

        public ApiResult(bool isSuccess, CustomApiResultStatusCode statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }

        #region Implicit Operators
        public static implicit operator ApiResult<TData>(TData data)
        {
            return new ApiResult<TData>(true, CustomApiResultStatusCode.Success, data);
        }

        public static implicit operator ApiResult<TData>(OkResult result)
        {
            return new ApiResult<TData>(true, CustomApiResultStatusCode.Success, null);
        }

        public static implicit operator ApiResult<TData>(OkObjectResult result)
        {
            return new ApiResult<TData>(true, CustomApiResultStatusCode.Success, (TData)result.Value);
        }

        public static implicit operator ApiResult<TData>(CreatedResult result)
        {
            return new ApiResult<TData>(true, CustomApiResultStatusCode.Success, null);
        }

        public static implicit operator ApiResult<TData>(CreatedAtActionResult result)
        {
            return new ApiResult<TData>(true, CustomApiResultStatusCode.Success, null);
        }

        public static implicit operator ApiResult<TData>(BadRequestResult result)
        {
            return new ApiResult<TData>(false, CustomApiResultStatusCode.BadRequest, null);
        }

        public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
        {
            var message = result.Value?.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult<TData>(false, CustomApiResultStatusCode.BadRequest, null, message);
        }

        public static implicit operator ApiResult<TData>(ContentResult result)
        {
            return new ApiResult<TData>(true, CustomApiResultStatusCode.Success, null, result.Content);
        }

        public static implicit operator ApiResult<TData>(NotFoundResult result)
        {
            return new ApiResult<TData>(false, CustomApiResultStatusCode.NotFound, null);
        }

        public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
        {
            return new ApiResult<TData>(false, CustomApiResultStatusCode.NotFound, (TData)result.Value);
        }
        #endregion
    }
}
