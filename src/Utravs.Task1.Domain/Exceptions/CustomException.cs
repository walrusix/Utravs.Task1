using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Domain.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public CustomApiResultStatusCode ApiStatusCode { get; set; }
        public object AdditionalData { get; set; }

        public List<ValidationErrorResult> ValidationErrorResults { set; get; }
        public bool IsValidationError { get; set; }

        public CustomException()
        {
        }

        public CustomException(CustomApiResultStatusCode statusCode)
            : this(statusCode, null)
        {
        }



        //public CustomException(List<ValidationErrorResult> validationErrorResults)
        //{
        //    ValidationErrorResults = validationErrorResults;
        //}



        public CustomException(CustomValidationResult customValidationResult)
        {
            ValidationErrorResults = new List<ValidationErrorResult>();
            ValidationErrorResults.Add(new ValidationErrorResult(customValidationResult, null));
        }

        public CustomException(CustomValidationResult customValidationResult, string param)
        {
            if (ValidationErrorResults == null) ValidationErrorResults = new List<ValidationErrorResult>();
            ValidationErrorResults.Add(new ValidationErrorResult(customValidationResult, param));
        }
        public CustomException(ValidationErrorResult validationErrorResult)
        {
            ValidationErrorResults.Add(validationErrorResult);
        }

        public CustomException(CustomApiResultStatusCode statusCode, string message)
            : this(statusCode, message, HttpStatusCode.InternalServerError)
        {
        }

        /// <summary>
        /// This constructor is used for validation
        /// </summary>
        /// <param name="items"></param>
        public CustomException(List<CustomApiResultStatusCode> items)
        {
            ApiStatusCode = CustomApiResultStatusCode.BadRequest;
            this.AdditionalData = items;
            IsValidationError = true;

        }

        public CustomException(string message, object additionalData)
            : this(CustomApiResultStatusCode.ServerError, message, additionalData)
        {
        }

        public CustomException(CustomApiResultStatusCode statusCode, object additionalData)
            : this(statusCode, null, additionalData)
        {
        }

        public CustomException(CustomApiResultStatusCode statusCode, string message, object additionalData)
            : this(statusCode, message, HttpStatusCode.InternalServerError, additionalData)
        {
        }

        public CustomException(CustomApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode)
            : this(statusCode, message, httpStatusCode, null)
        {
        }

        public CustomException(CustomApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode, object additionalData)
            : this(statusCode, message, httpStatusCode, null, additionalData)
        {
        }

        public CustomException(string message, Exception exception)
            : this(CustomApiResultStatusCode.ServerError, message, exception)
        {
        }

        public CustomException(string message, Exception exception, object additionalData)
            : this(CustomApiResultStatusCode.ServerError, message, exception, additionalData)
        {
        }

        public CustomException(CustomApiResultStatusCode statusCode, string message, Exception exception)
            : this(statusCode, message, HttpStatusCode.InternalServerError, exception)
        {
        }

        public CustomException(CustomApiResultStatusCode statusCode, string message, Exception exception, object additionalData)
            : this(statusCode, message, HttpStatusCode.InternalServerError, exception, additionalData)
        {
        }

        public CustomException(CustomApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode, Exception exception)
            : this(statusCode, message, httpStatusCode, exception, null)
        {
        }

        public CustomException(CustomApiResultStatusCode statusCode, string message, HttpStatusCode httpStatusCode, Exception exception, object additionalData)
            : base(message, exception)
        {
            ApiStatusCode = statusCode;
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
        }
    }
}
