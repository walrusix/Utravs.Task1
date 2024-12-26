using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Utravs.Task1.Domain.Exceptions;

namespace Utravs.Task1.Application.Commands
{
    public class BookingBookCommand : IRequest<List<ValidationErrorResult>>
    {
        public string FlightNumber { set; get; }
        public int PassengerId { set; get; }
        public int SeatNumber { set; get; }
    }
}
