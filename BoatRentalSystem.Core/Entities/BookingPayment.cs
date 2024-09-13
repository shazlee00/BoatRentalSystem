namespace BoatRentalSystem.Core.Entities
{
    public class BookingPayment
   {
       public int Id { get; set; }

       public int CustomerId { get; set; }
       public Customer Customer { get; set; }

       public int OwnerId { get; set; }
       public Owner Owner { get; set; }

        public int BookingId { get; set; }
        public BoatBooking Booking { get; set; }
        public bool PaymentStatus { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public double Amount { get; set; }

   }


    


}
