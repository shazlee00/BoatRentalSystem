using BoatRentalSystem.Core.Entities;

namespace BoatRentalSystem.Application.Payment.ViewModels
{
    public class CancellationDto
    {
        public int CancellationId { get; set; }

        public int CustomerId { get; set; }
  

        public int? ReservationId { get; set; }
    
        public int? BoatBookingId { get; set; }
     

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public double RefundAmount { get; set; } = 0;

        public DateTime CancellationDate { get; set; }


    }
}