using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserId { get; set; } //UserID from Asp.net Identity

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal WalletBalance { get; set; } = 0.0m;
        
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime UpdatedAt { get; set; }

            

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Cancellation> Cancellations { get; set; }
        public ICollection<BoatBooking> BoatBookings { get; set; }
    }
}
