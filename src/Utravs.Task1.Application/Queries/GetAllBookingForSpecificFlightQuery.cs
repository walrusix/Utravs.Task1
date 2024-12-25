using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Application.Queries
{
    public class GetAllBookingForSpecificFlightQuery : IRequest<List<Booking>>, IRequest
    {
        public string FlightNumber { set; get; }
    }
}
