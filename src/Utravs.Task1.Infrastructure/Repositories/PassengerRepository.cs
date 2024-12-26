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
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PassengerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> CreateAsync(Passenger passenger,CancellationToken cancellationToken)
        {
            var passengerEntity = new Entities.Passenger
                {
                    Email = passenger.Email,
                    FullName = passenger.FullName,
                    PassportNumber = passenger.PassportNumber
                };
            await _applicationDbContext
                .Passengers
                .AddAsync(passengerEntity, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return passengerEntity.Id;
        }

        public async Task<Paging<Passenger>> GetAsync(GridifyQuery gQuery, CancellationToken cancellationToken)
        {
            return await _applicationDbContext
                .Passengers
                .Select(p=> new Passenger
                {
                    Email = p.Email,
                    FullName = p.FullName,
                    PassportNumber = p.PassportNumber
                })
                .GridifyAsync(gQuery, cancellationToken);
        }

        public async Task<bool> CheckExistAsync(int id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext
                .Passengers
                .AnyAsync(p=>p.Id==id, cancellationToken);
        }
    }
}
