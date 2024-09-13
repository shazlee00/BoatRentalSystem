using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Entities
{
    public class ReservationPayment
    {

        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public bool PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; }=DateTime.Now;


        public double Amount { get; set; }
    }


    


}
