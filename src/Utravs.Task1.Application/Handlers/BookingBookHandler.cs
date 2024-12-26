using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Application.Commands;
using Utravs.Task1.Application.IRepository;
using Utravs.Task1.Domain.Exceptions;

namespace Utravs.Task1.Application.Handlers
{
    public class BookingBookHandler : IRequestHandler<BookingBookCommand, List<ValidationErrorResult>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IPassengerRepository _passengerRepository;

        public BookingBookHandler(IBookingRepository bookingRepository,
            IFlightRepository flightRepository,
            IPassengerRepository passengerRepository)
        {
            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
            _passengerRepository = passengerRepository;
        }
        public async Task<List<ValidationErrorResult>> Handle(BookingBookCommand request, CancellationToken cancellationToken)
        {
            #region LogicalInputCheck
            var validationErrors = new List<ValidationErrorResult>();
            var flightExist = await _flightRepository.CheckExistAsync(request.FlightNumber,cancellationToken);
            var passengerExist = await _passengerRepository.CheckExistAsync(request.PassengerId, cancellationToken);
            if(flightExist==false) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.InvalidValue, nameof(request.FlightNumber)));
            if (passengerExist == false) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.InvalidValue, nameof(request.PassengerId)));
            if (validationErrors.Any()) return validationErrors;
         var checkAvailableSeats =
                await _flightRepository.CheckAvailableSeats(request.FlightNumber, request.SeatNumber,
                    cancellationToken);
            if(checkAvailableSeats==false) validationErrors.Add(new ValidationErrorResult(CustomValidationResult.ThereIsNoEnoughSeats, nameof(request.FlightNumber)));
            if (validationErrors.Any()) return validationErrors;
            #endregion

            await _bookingRepository.BookAsync(request.FlightNumber, request.PassengerId, request.SeatNumber, cancellationToken);
            return null;
        }
    }
}
