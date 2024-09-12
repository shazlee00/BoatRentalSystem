namespace BoatRentalSystem.Core.Entities
{
    public class BoatBooking
    {
        public int BoatBookingId { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public int BoatId { get; set; }
        
        public Boat Boat { get; set; }

        public DateTime BookingDate { get; set; }
        public int DurationHours { get; set; }


        public double TotalPrice { get => (Boat?.ReservationPrice ?? 0) + (BookingAdditions?.Sum(x => x.TotalPrice) ?? 0); }

        public BoatBookingStatus Status { get; set; }
        public DateTime? CanceledAt { get; set; } 

        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime UpdatedAt { get; set; }

      
          

       
        public List<BookingAddition> BookingAdditions { get; set; }
      
    }


public enum BoatBookingStatus
    {
        Pending,
        Confirmed,
        Canceled
    }



}