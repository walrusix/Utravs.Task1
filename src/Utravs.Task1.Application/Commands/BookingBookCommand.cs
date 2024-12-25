using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Utravs.Task1.Application.Commands
{
    public class BookingBookCommand : IRequest<bool>
    {
        public int FlightId { set; get; }
        public int PassengerId { set; get; }
        public int SeatNumber { set; get; }
    }
}
