using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Utravs.Task1.Application.Commands;
using Utravs.Task1.Application.ViewModels.Passenger;
using Utravs.Task1.EndPoints.WebApi.Controllers;

namespace Utravs.Task1.Tests.Controller
{
    public class PassengerControllerTests
    {
        private readonly IMediator _mediator;
        public PassengerControllerTests()
        {
            _mediator = A.Fake<IMediator>();
        }

        [Fact]
        public async void PassengerController_CreatePassenger_ReturnOk()
        {
            var passengerController = new PassengerController(_mediator);

            var result =await passengerController.Create(new PassengerCreateRequestViewModel
            {
                FullName = "Amin Ahmadi",
                PassportNumber = "09155",
                PhoneNumber = null,
                Email = "Amin.ahmadi.asl@gmail.com"
            }, CancellationToken.None);
            result.Should().BeOfType(typeof(CreatedResult));
        }



    }
}
