using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gridify;
using MediatR;
using Utravs.Task1.Application.IRepository;
using Utravs.Task1.Application.Queries;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Application.Handlers
{
    public class PassengerGetHandler : IRequestHandler<PassengerGetQuery,Paging<Domain.Domain.Passenger>>
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerGetHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        public async Task<Paging<Passenger>> Handle(PassengerGetQuery request, CancellationToken cancellationToken)
        {
            return await _passengerRepository.GetAsync(request.Query, cancellationToken);
        }
    }
}
