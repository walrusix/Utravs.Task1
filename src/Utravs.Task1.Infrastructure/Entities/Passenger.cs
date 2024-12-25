using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utravs.Task1.Infrastructure.Entities
{
    public class Passenger
    {
        public int Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string PassportNumber { set; get; }
    }

    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {

        }
    }
}
