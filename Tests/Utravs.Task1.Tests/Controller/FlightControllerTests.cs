using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Utravs.Task1.Application.ViewModels.Flight;
using Utravs.Task1.Application.ViewModels.Passenger;
using Utravs.Task1.EndPoints.WebApi.Controllers;

namespace Utravs.Task1.Tests.Controller
{
    public class FlightControllerTests
    {
        private readonly IMediator _mediator;
        public FlightControllerTests()
        {
            _mediator = A.Fake<IMediator>();
        }

        [Fact]
        public async void FlightController_CreatePassenger_ReturnOk()
        {
            var flightController = new FlightController(_mediator);

            var result = await flightController.Create(new FlightCreateRequestViewModel
            {
                ArrivalTime = DateTime.Now,
                AvailableSeats = 5,
                Destination = "UTravs",
                Origin = "Mashhad",
                FlightNumber = "Flight1",
                DepartureTime = DateTime.Now,
                Price = 5000
            }, CancellationToken.None);
            result.Should().BeOfType(typeof(CreatedResult));
        }
    }
}
