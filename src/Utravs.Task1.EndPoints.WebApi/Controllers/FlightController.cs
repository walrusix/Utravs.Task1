using Gridify;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utravs.Task1.Application.Commands;
using Utravs.Task1.Application.Queries;
using Utravs.Task1.Application.ViewModels.Flight;
using Utravs.Task1.EndPoints.WebApi.Filters;

namespace Utravs.Task1.EndPoints.WebApi.Controllers
{

    public class FlightController : EndUserBaseController
    {
        private readonly IMediator _mediator;

        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GridifyQuery gQuery, CancellationToken cancellationToken)
        {
            var query = new FlightGetQuery(gQuery);
            var result = _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FlightCreateRequestViewModel model, CancellationToken cancellationToken)
        {
            var command = new FlightCreateCommand
            {
                ArrivalTime = (DateTime)model.ArrivalTime,
                AvailableSeats = (int)model.AvailableSeats,
                DepartureTime = (DateTime)model.DepartureTime,
                Destination = model.Destination,
                FlightNumber = model.FlightNumber,
                Origin = model.Origin,
                Price =(decimal) model.Price,
            };
            var result = _mediator.Send(command, cancellationToken);
            return Created("",result);
        }

        [HttpPut]
        public async Task<IActionResult> Get(FlightUpdateSeatsRequestViewModel model, CancellationToken cancellationToken)
        {
            var command = new FlightUpdateSeatsCommand
            {
                FlightId = model.FlightId,
                Seats = model.Seats
            };
            var result = _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
