using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Application.ViewModels.Flight
{
    public class FlightUpdateSeatsRequestViewModel
    {
        public int FlightId { set; get; }
        public int Seats { set; get; }
    }
}
