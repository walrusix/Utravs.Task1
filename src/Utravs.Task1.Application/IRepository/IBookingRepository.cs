using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Application.IRepository
{
    public interface IBookingRepository
    {
        Task<bool> BookAsync(int flightId, int passengerId,int seatNumber,CancellationToken cancellationToken);
        Task<List<Booking>> GetAsync(int flightId);
    }
}
