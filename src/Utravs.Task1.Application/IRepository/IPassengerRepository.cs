using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gridify;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Application.IRepository
{
    public interface IPassengerRepository
    {
        Task<int> CreateAsync(Domain.Domain.Passenger passenger, CancellationToken cancellationToken);
        Task<Paging<Passenger>> GetAsync(GridifyQuery gQuery, CancellationToken cancellationToken);
        Task<bool> CheckExistAsync(int id, CancellationToken cancellationToken);
    }
}
