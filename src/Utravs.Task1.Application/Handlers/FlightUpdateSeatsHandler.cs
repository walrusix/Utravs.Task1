using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Application.Commands;
using Utravs.Task1.Application.IRepository;

namespace Utravs.Task1.Application.Handlers
{
    public class FlightUpdateSeatsHandler : IRequestHandler<FlightUpdateSeatsCommand, bool>
    {
        private readonly IFlightRepository _flightRepository;

        public FlightUpdateSeatsHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public async Task<bool> Handle(FlightUpdateSeatsCommand request, CancellationToken cancellationToken)
        {
            return await _flightRepository.UpdateSeatAsync(request.FlightId, request.Seats, cancellationToken);
        }
    }
}
