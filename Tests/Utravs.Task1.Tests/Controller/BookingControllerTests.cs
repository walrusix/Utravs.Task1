using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Utravs.Task1.Application.ViewModels.Booking;
using Utravs.Task1.Application.ViewModels.Flight;
using Utravs.Task1.Application.ViewModels.Passenger;
using Utravs.Task1.Domain.Exceptions;
using Utravs.Task1.EndPoints.WebApi.Controllers;
using Exception = System.Exception;

namespace Utravs.Task1.Tests.Controller
{
    public class BookingControllerTests
    {
        private readonly IMediator _mediator;
        public BookingControllerTests()
        {
            _mediator = A.Fake<IMediator>();
        }

        [Fact]
        public async void BookingController_CreatePassenger_ReturnError()
        {
            var bookingController = new BookingController(_mediator);
            try
            {
                await bookingController.Book(new BookingBookRequestViewModel
                {
                    FlightNumber = "Flight1",
                    PassengerId = 1,
                    SeatNumber = 2
                }, CancellationToken.None);
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType(typeof(ValidationException));
            }
        }
    }
}
