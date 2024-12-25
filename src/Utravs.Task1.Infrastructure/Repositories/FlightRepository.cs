using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Utravs.Task1.Application.IRepository;
using Utravs.Task1.Domain.Domain;
using Utravs.Task1.Infrastructure.DbContext;

namespace Utravs.Task1.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FlightRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> CreateAsync(Flight flight, CancellationToken cancellationToken)
        {
            var flightEntity = new Entities.Flight
            {
                Id = flight.Id,
                Price = flight.Price,
                ArrivalTime = flight.ArrivalTime,
                AvailableSeats = flight.AvailableSeats,
                DepartureTime = flight.DepartureTime,
                Destination = flight.Destination,
                FlightNumber = flight.FlightNumber,
                Origin = flight.Origin
            };
            await _applicationDbContext.Flights.AddAsync(flightEntity, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return flightEntity.Id;
        }

        public async Task<Paging<Flight>> GetAsync(GridifyQuery gQuery, CancellationToken cancellationToken)
        {
            return await _applicationDbContext
                .Flights
                .AsNoTracking()
                .Select(p=>new Flight
                {
                    Origin = p.Origin,
                    FlightNumber = p.FlightNumber,
                    Destination = p.Destination,
                    DepartureTime = p.DepartureTime,
                    AvailableSeats = p.AvailableSeats,
                    Price = p.Price,
                    ArrivalTime = p.ArrivalTime,
                    Id = p.Id

                })
                .GridifyAsync(gQuery, cancellationToken);

        }

        public async Task<bool> UpdateSeatAsync(int flightNumber, int seatsCount, CancellationToken cancellationToken)
        {
            var flight = await _applicationDbContext
                .Flights
                .Where(p => p.Id == flightNumber)
                .FirstOrDefaultAsync(cancellationToken);
            flight.AvailableSeats = seatsCount;
            _applicationDbContext.Update(flight);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
