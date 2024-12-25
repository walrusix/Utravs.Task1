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
        public async Task<bool> BookAsync(int flightId, int passengerId,int seatNumber,CancellationToken cancellationToken)
        {
            var availableBooking = await _applicationDbContext
                .Bookings
                .Where(p => p.FlightId == flightId && p.SeatNumber != seatNumber)
                .AnyAsync(cancellationToken);
            if (availableBooking)
            {
                await _applicationDbContext
                    .Bookings
                    .AddAsync(new Entities.Booking
                    {
                        FlightId = flightId,
                        BookingDate = DateTime.Now,
                        PassengerId = passengerId,
                        SeatNumber = seatNumber
                    }, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public Task<List<Booking>> GetAsync(int flightId)
        {
            throw new NotImplementedException();
        }
    }
}
