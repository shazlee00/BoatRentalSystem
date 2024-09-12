using Serilog.Debugging;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoatRentalSystem.Core.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }  

     
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 

   
        public int TripId { get; set; }
        public Trip Trip { get; set; }

        [ForeignKey("BoatId")]
        public int BoatId { get; set; }
        public Boat Boat { get; set; }  

        public int NumberOfPeople { get; set; } 
        public double TotalPrice { get => (NumberOfPeople * (Boat?.ReservationPrice ?? 0)) + (ReservationAdditions?.Sum(x => x.TotalPrice) ?? 0); }

        public DateTime ReservationDate { get; set; } 

  
        public ReservationStatus Status { get; set; }

     
        public DateTime? CanceledAt { get; set; }

   
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    
        public DateTime? UpdatedAt { get; set; }

    
       public List<Addition> Additions { get; }= new List<Addition>();
        public List<ReservationAddition> ReservationAdditions { get; set; }  = new List<ReservationAddition>();
    
    }

 
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Canceled
    }

}