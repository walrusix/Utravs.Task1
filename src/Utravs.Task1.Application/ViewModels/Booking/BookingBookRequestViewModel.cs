using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utravs.Task1.Domain.Exceptions;
using Utravs.Task1.Domain.ExtenstionMethods;
using ValidationException = Utravs.Task1.Domain.Exceptions.ValidationException;

namespace Utravs.Task1.Application.ViewModels.Booking
{
    public class BookingBookRequestViewModel : IValidatableObject
    {
        public string FlightNumber { set; get; }
        public int? SeatNumber { set; get; }
        public int? PassengerId { set; get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationErrors = new List<ValidationErrorResult>();
            if (!FlightNumber.HasValue()) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(FlightNumber)));
            if (SeatNumber==null) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(SeatNumber)));
            if (PassengerId==null) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(PassengerId)));
            if (validationErrors.Any()) throw new ValidationException(validationErrors);
            return new List<ValidationResult>();
        }
    }
}
