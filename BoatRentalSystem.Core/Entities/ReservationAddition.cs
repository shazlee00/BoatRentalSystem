namespace BoatRentalSystem.Core.Entities
{
    public class ReservationAddition
    {
       // public int ReservationAdditionId { get; set; }  

      
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }  

   
        public int AdditionId { get; set; }
        public Addition Addition { get; set; }  

        public int Quantity { get; set; } 
        public double TotalPrice { get; set; }  



       
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}