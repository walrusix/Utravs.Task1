using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gridify;
using Utravs.Task1.Application.IRepository;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        public Task<int> CreateAsync(Flight flight, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Paging<Flight>> GetAsync(GridifyQuery gQuery, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSeatAsync(int flightNumber, int seatsCount, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
