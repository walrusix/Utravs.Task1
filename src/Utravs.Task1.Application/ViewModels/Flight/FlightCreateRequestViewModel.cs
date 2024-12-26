using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Domain.Exceptions;
using Utravs.Task1.Domain.ExtenstionMethods;
using ValidationException = Utravs.Task1.Domain.Exceptions.ValidationException;

namespace Utravs.Task1.Application.ViewModels.Flight
{
    public class FlightCreateRequestViewModel :IValidatableObject
    {
        public string FlightNumber { set; get; }
        public string Origin { set; get; }
        public string Destination { set; get; }
        public DateTime? DepartureTime { set; get; }
        public DateTime? ArrivalTime { set; get; }
        public int? AvailableSeats { set; get; }
        public decimal? Price { set; get; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationErrors = new List<ValidationErrorResult>();
            if (!FlightNumber.HasValue()) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(FlightNumber)));
            if (!Origin.HasValue()) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(Origin)));
            if (!Destination.HasValue()) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(Destination)));
            if (DepartureTime == null) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(DepartureTime)));
            if (ArrivalTime == null) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(ArrivalTime)));
            if (AvailableSeats == null) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(AvailableSeats)));
            if (Price == null) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThisFieldIsRequired, nameof(Price)));
            if (AvailableSeats < 0) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ValueMustBePositiveNumber, nameof(AvailableSeats)));
            if (Price < 0) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ValueMustBePositiveNumber, nameof(AvailableSeats)));
            if (validationErrors.Any()) throw new ValidationException(validationErrors);
            return new List<ValidationResult>();
        }
    }
}
