using Gridify;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Application.Queries
{
    public class PassengerGetQuery : IRequest<Paging<Domain.Domain.Passenger>>
    {
        public PassengerGetQuery(GridifyQuery gQuery)
        {
            Query = gQuery;
        }
        public GridifyQuery Query { set; get; }
    }
}
