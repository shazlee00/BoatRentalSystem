namespace BoatRentalSystem.Core.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }  

     
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 

   
        public int TripId { get; set; }
        public Trip Trip { get; set; }  

      
        public int BoatId { get; set; }
        public Boat Boat { get; set; }  

        public int NumberOfPeople { get; set; } 
        public double TotalPrice { get; set; }  

        public DateTime ReservationDate { get; set; } 

  
        public ReservationStatus Status { get; set; }

     
        public DateTime? CanceledAt { get; set; }

   
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    
        public DateTime? UpdatedAt { get; set; }

    
        public List<Addition> Additions { get; set; }=new List<Addition>();
        public List<ReservationAddition> ReservationAdditions { get; set; }  = new List<ReservationAddition>();
    }

 
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Canceled
    }

}