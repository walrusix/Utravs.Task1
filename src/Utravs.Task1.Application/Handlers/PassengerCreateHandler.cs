using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Application.Commands;
using Utravs.Task1.Application.IRepository;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Application.Handlers
{
    public class PassengerCreateHandler : IRequestHandler<PassengerCreateCommand, int>
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerCreateHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        public async Task<int> Handle(PassengerCreateCommand request, CancellationToken cancellationToken)
        {
            return await _passengerRepository.CreateAsync(new Passenger
            {
                Email = request.Email,
                FullName = request.FullName,
                PassportNumber = request.PassportNumber
            }, cancellationToken);
        }
    }
}
