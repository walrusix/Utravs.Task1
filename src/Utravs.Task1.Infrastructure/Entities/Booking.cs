using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Domain.Domain;

namespace Utravs.Task1.Infrastructure.Entities
{
    public class Booking
    {
        public int Id { set; get; }
        public int FlightId { set; get; }
        [ForeignKey("FlightId")]
        public virtual Flight Flight { set; get; }
        public int PassengerId { set; get; }
        [ForeignKey("PassengerId")]
        public Passenger Passenger { set; get; }
        public DateTime BookingDate { set; get; }
        public int SeatNumber { set; get; }
    }
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {

        }
    }

}
