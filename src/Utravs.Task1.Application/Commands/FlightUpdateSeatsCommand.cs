using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Application.Commands
{
    public class FlightUpdateSeatsCommand : IRequest<bool>
    {
        public int FlightId { set; get; }
        public int Seats { set; get; }
    }
}
