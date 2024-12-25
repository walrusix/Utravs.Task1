using Gridify;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Application.IRepository;
using Utravs.Task1.Application.Queries;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Application.Handlers
{
    public class FlightGetHandler : IRequestHandler<FlightGetQuery, Paging<Domain.Domain.Flight>>
    {
        private readonly IFlightRepository _flightRepository;

        public FlightGetHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public async Task<Paging<Flight>> Handle(FlightGetQuery request, CancellationToken cancellationToken)
        {
            return await _flightRepository
                .GetAsync(request.Query, cancellationToken);
        }
    }
}
