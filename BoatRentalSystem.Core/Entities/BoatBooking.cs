namespace BoatRentalSystem.Core.Entities
{
    public class BoatBooking
    {
        public int BookingId { get; set; }

        public int CustomerId { get; set; }

   
        public int BoatId { get; set; }

   
        public DateTime BookingDate { get; set; }
        public int DurationHours { get; set; }
        public decimal TotalPrice { get; set; }

    
        public BoatBookingStatus Status { get; set; }
        public DateTime? CanceledAt { get; set; } 

        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime UpdatedAt { get; set; }

      
        public Customer Customer { get; set; }  
        public Boat Boat { get; set; }        

       
        public IEnumerable<BookingAddition> BookingAdditions { get; set; }
    }


public enum BoatBookingStatus
    {
        Pending,
        Confirmed,
        Canceled
    }



}