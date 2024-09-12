using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Entities
{
    public class Cancellation
    {
        public int CancellationId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? ReservationId { get; set; }
        public Reservation? Reservation     { get; set; }

        public int? BoatBookingId { get; set; }
        public BoatBooking? BoatBooking { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public decimal RefundAmount { get; set; } = 0;

        public DateTime CancellationDate { get; set; }




    }
}
