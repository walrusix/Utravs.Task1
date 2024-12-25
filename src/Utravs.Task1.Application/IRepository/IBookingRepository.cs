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
        Task<int> BookAsync(int flightNumber, int passengerId);
        Task<List<Booking>> GetAsync(int flightId);
    }
}
