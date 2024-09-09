using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Entities
{
    public class Trip
    {
        public int TripId { get; set; }    
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }  

       
        public int BoatId { get; set; }
        public Boat Boat { get; set; } 

        public string Name { get; set; }  
        public string Description { get; set; }  
        public double PricePerPerson { get; set; } 
        public int MaxPeople { get; set; }  

        public DateTime CancellationDeadline { get; set; }

        public TripStatus Status { get; set; }

        public DateTime? StartedAt { get; set; }  

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

      
        public List<Reservation> Reservations { get; set; }
    }

    // Enum for Trip status
    public enum TripStatus
    {
        Pending,
        Active,
        Canceled,
        Completed
    }

}
