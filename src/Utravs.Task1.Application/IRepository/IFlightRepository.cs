using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gridify;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Application.IRepository
{
    public interface IFlightRepository
    {
        Task<int> CreateAsync(Flight flight, CancellationToken cancellationToken);
        Task<Gridify.Paging<Flight>> GetAsync(GridifyQuery gQuery, CancellationToken cancellationToken);
        Task<bool> UpdateSeatAsync(int flightNumber, int seatsCount, CancellationToken cancellationToken);
    }
}
