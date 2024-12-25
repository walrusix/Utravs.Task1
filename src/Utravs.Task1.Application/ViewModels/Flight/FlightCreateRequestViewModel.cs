using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Domain.Exceptions;
using ValidationException = Utravs.Task1.Domain.Exceptions.ValidationException;

namespace Utravs.Task1.Application.ViewModels.Flight
{
    public class FlightCreateRequestViewModel :IValidatableObject
    {
        public string FlightNumber { set; get; }
        public string Origin { set; get; }
        public string Destination { set; get; }
        public DateTime DepartureTime { set; get; }
        public DateTime ArrivalTime { set; get; }
        public int AvailableSeats { set; get; }
        public decimal Price { set; get; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationErrors = new List<ValidationErrorResult>();
            if (AvailableSeats<0) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.SeatNumberMustBePositiveNumber, nameof(AvailableSeats)));
            if (validationErrors.Any()) throw new ValidationException(validationErrors);
            return new List<ValidationResult>();
        }
    }
}
