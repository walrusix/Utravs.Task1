using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Utravs.Task1.Application.IRepository;
using Utravs.Task1.Domain.Domain;
using Utravs.Task1.Infrastructure.DbContext;

namespace Utravs.Task1.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> BookAsync(string flightNumber, int passengerId,int seatNumber,CancellationToken cancellationToken)
        {
            var flight = await _applicationDbContext
                .Flights
                .Where(p => p.FlightNumber == flightNumber)
                .FirstOrDefaultAsync(cancellationToken);
            var availableBooking = await _applicationDbContext
                .Bookings
                .Where(p => p.Flight.FlightNumber == flightNumber && p.SeatNumber >= seatNumber)
                .AnyAsync(cancellationToken);
            if (availableBooking)
            {
                await _applicationDbContext
                    .Bookings
                    .AddAsync(new Entities.Booking
                    {
                        FlightId = flight.Id,
                        BookingDate = DateTime.Now,
                        PassengerId = passengerId,
                        SeatNumber = seatNumber
                    }, cancellationToken);
                flight.AvailableSeats -=seatNumber;
                _applicationDbContext.Flights.Update(flight);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<List<Booking>> GetAsync(string flightNumber,CancellationToken cancellationToken)
        {
            return await _applicationDbContext
                .Bookings
                .AsNoTracking()
                .Where(p => p.Flight.FlightNumber == flightNumber)
                .Select(p => new Booking
                {
                    BookingDate = p.BookingDate,
                    FlightId = p.FlightId,
                    Id = p.Id,
                    PassengerId = p.PassengerId,
                    SeatNumber = p.SeatNumber
                })
                .ToListAsync(cancellationToken);
        }
    }
}
