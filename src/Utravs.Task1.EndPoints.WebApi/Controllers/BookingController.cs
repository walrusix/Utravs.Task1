using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utravs.Task1.Application.Commands;
using Utravs.Task1.Application.Queries;
using Utravs.Task1.Application.ViewModels.Booking;
using Utravs.Task1.Domain.Exceptions;
using Utravs.Task1.EndPoints.WebApi.Filters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Utravs.Task1.EndPoints.WebApi.Controllers
{

    public class BookingController : EndUserBaseController
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookingBookRequestViewModel model, CancellationToken cancellationToken)
        {
            
                var command = new BookingBookCommand
                {
                    FlightNumber = model.FlightNumber,
                    SeatNumber = (int)model.SeatNumber,
                    PassengerId = (int)model.PassengerId
                };
                var result = await _mediator.Send(command, cancellationToken);
                if (result == null) return Created("SomeAddressToRetriveThisBook", result);
                else throw new ValidationException(result);
        }


        [HttpGet("{flightNumber}")]
        public async Task<IActionResult> GetAllBookingForSpecificFlight([FromRoute] string flightNumber,
            CancellationToken cancellationToken)
        {
            var query = new GetAllBookingForSpecificFlightQuery { FlightNumber = flightNumber };
            var result = _mediator.Send(query,cancellationToken);
            return Ok(result);
        }
    }
}
