namespace BoatRentalSystem.Core.Entities
{
    public class BookingAddition
    {
        public int BookingAdditionId { get; set; }

     
        public int BoatBookingId { get; set; }

        public BoatBooking BoatBooking { get; set; }
        
        public int AdditionId { get; set; }

        public Addition Addition { get; set; }


       
        public int Quantity { get; set; }
        public double TotalPrice { get => Quantity * (Addition?.Price ?? 0); }

        
        public DateTime CreatedAt { get; set; }=DateTime.Now;

      
   
    }
}
