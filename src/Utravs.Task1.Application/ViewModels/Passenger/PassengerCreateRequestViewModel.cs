using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Application.ViewModels.Passenger
{
    public class PassengerCreateRequestViewModel
    {
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PassportNumber { set; get; }
    }
}
