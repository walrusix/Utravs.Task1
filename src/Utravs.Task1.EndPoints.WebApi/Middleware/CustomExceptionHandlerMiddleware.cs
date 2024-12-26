using System.Net;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Utravs.Task1.Domain.Exceptions;
using Utravs.Task1.Domain.ExtenstionMethods;

namespace Utravs.Task1.EndPoints.WebApi.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }

    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public CustomExceptionHandlerMiddleware(RequestDelegate next,
            IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor
           )
        {
            _next = next;
            _env = env;

        }

        public async Task Invoke(HttpContext context)
        {
            string message = null;
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            CustomApiResultStatusCode apiStatusCode = CustomApiResultStatusCode.ServerError;

            try
            {
                await _next(context);
            }

            catch (CustomException exception)
            {
                if (exception.ValidationErrorResults != null)
                {
                    foreach (var exceptionValidationErrorResult in exception.ValidationErrorResults)
                    {
                        exceptionValidationErrorResult.Description =
                            exceptionValidationErrorResult.Status.ToDisplay();
                        if (exceptionValidationErrorResult.Param != null)
                        {
                            var field = exceptionValidationErrorResult.Param;


                            exceptionValidationErrorResult.Description =
                                exceptionValidationErrorResult.Description.Replace("[Field]", field);
                            if (exceptionValidationErrorResult.Params != null)
                            {
                                for (var paramCursor = 0;
                                     paramCursor < exceptionValidationErrorResult.Params.Length;
                                     paramCursor++)

                                {
                                    exceptionValidationErrorResult.Description =
                                        exceptionValidationErrorResult.Description.Replace($"[Param{paramCursor}]",
                                            exceptionValidationErrorResult.Params[paramCursor],
                                            StringComparison.OrdinalIgnoreCase);
                                    exceptionValidationErrorResult.Description =
                                        exceptionValidationErrorResult.Description.Replace($"[پارام{paramCursor}]",
                                            exceptionValidationErrorResult.Params[paramCursor],
                                            StringComparison.OrdinalIgnoreCase);
                                }
                            }
                        }


                    }
                }
                else
                {
                    apiStatusCode = exception.ApiStatusCode;
                    httpStatusCode = exception.HttpStatusCode;
                }

                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace,
                    };
                    if (exception.InnerException != null)
                    {
                        dic.Add("InnerException.Exception", exception.InnerException.Message);
                        dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                    }

                    if (exception.AdditionalData != null)
                        dic.Add("AdditionalData", JsonConvert.SerializeObject(exception.AdditionalData));

                    message = JsonConvert.SerializeObject(dic);
                }
                else
                {
                    message = exception.Message;
                }

                await WriteToResponseAsync(exception);
            }

            catch (Exception exception)
            {
                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace,
                    };
                    message = JsonConvert.SerializeObject(dic);
                }
                await WriteToResponseAsync(exception);
            }

            async Task WriteToResponseAsync(Exception? ex = null)
            {
                if (context.Response.HasStarted)
                    throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");
                var result = new ApiResult.ApiResult(false, apiStatusCode, message);
                /////////////////////////////////////////////////////////////
                if (ex != null && ex is CustomException exc)
                {
                    if (exc.ValidationErrorResults == null)
                    {
                        result.Errors = null;
                        result.StatusCode = exc.ApiStatusCode;
                        result.Description = result.StatusCode.ToDisplay();
                    }
                    else if (exc.ValidationErrorResults.Any())
                    {
                        httpStatusCode = HttpStatusCode.OK;
                        result.Errors = exc.ValidationErrorResults;
                        result.StatusCode = CustomApiResultStatusCode.ValidationError;
                        result.Description = result.StatusCode.ToDisplay();
                    }
                }
                var json = JsonConvert.SerializeObject(result);

                context.Response.StatusCode = (int)httpStatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }

            
        }
    }
}
