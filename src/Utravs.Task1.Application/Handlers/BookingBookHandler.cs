using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Application.Commands;
using Utravs.Task1.Application.IRepository;

namespace Utravs.Task1.Application.Handlers
{
    public class BookingBookHandler : IRequestHandler<BookingBookCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingBookHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<bool> Handle(BookingBookCommand request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.BookAsync(request.FlightNumber, request.PassengerId,request.SeatNumber, cancellationToken);
        }
    }
}
