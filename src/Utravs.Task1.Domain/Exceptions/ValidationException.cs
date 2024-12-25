using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Domain.Exceptions
{
    public class ValidationException : CustomException
    {
        public ValidationException(CustomValidationResult customValidationResult)
        {
            ValidationErrorResults = new List<ValidationErrorResult>();
            ValidationErrorResults.Add(new ValidationErrorResult(customValidationResult, null));
        }
        public ValidationException(List<ValidationErrorResult> validationErrorResults)
        {
            ValidationErrorResults = validationErrorResults;
        }
        public ValidationException(CustomValidationResult customValidationResult, string field)
        {
            ValidationErrorResults = new List<ValidationErrorResult>();
            ValidationErrorResults.Add(new ValidationErrorResult(customValidationResult, field));
        }
        public ValidationException(CustomValidationResult customValidationResult, string field, params string[] paramList)
        {
            ValidationErrorResults = new List<ValidationErrorResult>();
            ValidationErrorResults.Add(new ValidationErrorResult(customValidationResult, field, paramList));
        }


    }
    //public class InvalidParameterValidationException : ValidationException
    //{
    //    public InvalidParameterValidationException() : base(CustomValidationResult.InvalidParameter)
    //    {
    //    }

    //    public InvalidParameterValidationException(List<ValidationErrorResult> validationErrorResults) : base(validationErrorResults)
    //    {
    //    }

    //    public InvalidParameterValidationException(string field) : base(CustomValidationResult.InvalidParameter, field)
    //    {
    //    }

    //    public InvalidParameterValidationException(string field, params string[] paramList) : base(CustomValidationResult.InvalidParameter, field, paramList)
    //    {
    //    }
    //}
}
