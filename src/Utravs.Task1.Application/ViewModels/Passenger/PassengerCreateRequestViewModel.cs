using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utravs.Task1.Domain.Exceptions;
using Utravs.Task1.Domain.ExtenstionMethods;
using ValidationException = Utravs.Task1.Domain.Exceptions.ValidationException;

namespace Utravs.Task1.Application.ViewModels.Passenger
{
    public class PassengerCreateRequestViewModel : IValidatableObject
    {
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PassportNumber { set; get; }
        public string PhoneNumber { set; get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationErrors = new List<ValidationErrorResult>();
            if (!FullName.HasValue()) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(FullName)));
            if (!Email.HasValue()) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(Email)));
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);
            if (!match.Success) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.InvalidFormat, nameof(Email)));
            if (!PassportNumber.HasValue()) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(PassportNumber)));
            if (validationErrors.Any()) throw new ValidationException(validationErrors);
            return new List<ValidationResult>();
        }
    }
}
