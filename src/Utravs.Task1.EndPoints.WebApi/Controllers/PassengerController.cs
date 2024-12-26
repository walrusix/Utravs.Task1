using Gridify;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utravs.Task1.Application.Commands;
using Utravs.Task1.Application.Queries;
using Utravs.Task1.Application.ViewModels.Passenger;
using Utravs.Task1.EndPoints.WebApi.Filters;

namespace Utravs.Task1.EndPoints.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiResultFilter]
    public class PassengerController : Controller
    {
        private readonly IMediator _mediator;

        public PassengerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(PassengerCreateRequestViewModel model, CancellationToken cancellationToken)
        {
            var command = new PassengerCreateCommand
            {
                Email = model.Email,
                FullName = model.FullName,
                PassportNumber = model.PassportNumber,
                PhoneNumber = model.PhoneNumber
            };
            var result = _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GridifyQuery gQuery, CancellationToken cancellationToken)
        {
            var query = new PassengerGetQuery(gQuery);
            var result = _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
