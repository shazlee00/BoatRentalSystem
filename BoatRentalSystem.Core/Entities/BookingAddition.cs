namespace BoatRentalSystem.Core.Entities
{
    public class BookingAddition
    {
        public int BookingAdditionId { get; set; }

     
        public int BooatBookingId { get; set; }

        public BoatBooking BoatBooking { get; set; }
        
        public int AdditionId { get; set; }

        public Addition Addition { get; set; }
       
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        
        public DateTime CreatedAt { get; set; }=DateTime.Now;

      
   
    }
}
