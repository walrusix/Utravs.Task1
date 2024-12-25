using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Utravs.Task1.Application.Commands
{
    public class PassengerCreateCommand :IRequest<int>
    {
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PassportNumber { set; get; }
    }
}
