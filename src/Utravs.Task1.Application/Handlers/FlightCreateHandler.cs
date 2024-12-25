using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Utravs.Task1.Application.Commands;
using Utravs.Task1.Application.IRepository;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Application.Handlers
{
    public class FlightCreateHandler : IRequestHandler<FlightCreateCommand,int>
    {
        private readonly IFlightRepository _flightRepository;

        public FlightCreateHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public async Task<int> Handle(FlightCreateCommand request, CancellationToken cancellationToken)
        {
            return await _flightRepository.CreateAsync(new Flight
            {
                Origin = request.Origin,
                FlightNumber = request.FlightNumber,
                Destination = request.Destination,
                DepartureTime = request.DepartureTime,
                ArrivalTime = request.ArrivalTime,
                AvailableSeats = request.AvailableSeats,
                Price = request.Price,
            }, cancellationToken);
        }
    }
}
