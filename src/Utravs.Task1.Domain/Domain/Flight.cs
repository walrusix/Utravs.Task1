using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Domain.Domain
{
    public class Flight
    {
        public int Id { set; get; }
        public string FlightNumber { set; get; }
        public string Origin { set; get; }
        public string Destination { set; get; }
        public DateTime DepartureTime { set; get; }
        public DateTime ArrivalTime { set; get; }
        public int AvailableSeats { set; get; }
        public decimal Price { set; get; }
    }
}
