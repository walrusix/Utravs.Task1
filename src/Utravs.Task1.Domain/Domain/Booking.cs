using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Domain.Domain
{
    public class Booking
    {
        public int Id { set; get; }
        public int FlightId { set; get; }
        public virtual Flight Flight { set; get; }
        public int PassengerId { set; get; }
        public Passenger Passenger { set; get; }
        public DateTime BookingDate { set; get; }
        public int SeatNumber { set; get; }
    }
}
