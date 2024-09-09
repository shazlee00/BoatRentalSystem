using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Entities
{
    public class Boat
    {
        public int BoatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public int Capacity { get; set; }

        public double ReservationPrice { get; set; }

        public BoatStatus Status { get; set; }


        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
     

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        public List<Trip> Trips { get; set; } = new List<Trip>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<BoatBooking> BoatBookings { get; set; } = new List<BoatBooking>();

    }


    public enum BoatStatus
    {
       Pending,
       Approved,
       Rejected
    }



}
