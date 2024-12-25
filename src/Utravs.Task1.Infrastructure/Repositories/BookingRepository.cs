using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Task<int> BookAsync(int flightNumber, int passengerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Booking>> GetAsync(int flightId)
        {
            throw new NotImplementedException();
        }
    }
}
