using Gridify;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Application.Queries
{
    public class FlightGetQuery : IRequest<Paging<Domain.Domain.Flight>>
    {
        public FlightGetQuery(GridifyQuery query)
        {
            Query = query;
        }
        public GridifyQuery Query { set; get; }
    }
}
