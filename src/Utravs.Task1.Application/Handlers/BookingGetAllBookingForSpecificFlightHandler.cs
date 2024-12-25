using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Utravs.Task1.Application.IRepository;
using Utravs.Task1.Application.Queries;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Application.Handlers
{
    public class BookingGetAllBookingForSpecificFlightHandler : IRequestHandler<GetAllBookingForSpecificFlightQuery, List<Booking>>
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingGetAllBookingForSpecificFlightHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<List<Booking>> Handle(GetAllBookingForSpecificFlightQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetAsync(request.FlightNumber,cancellationToken);
        }
    }
}
