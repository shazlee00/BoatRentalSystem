using BoatRentalSystem.Application.Reservation.ViewModels;

namespace BoatRentalSystem.Application.Payment.ViewModels
{
    public class PaymentDto
    {

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int? TripId { get; set; }

        public string? TripName { get; set; }


        public int? BookingId { get; set; }


        public List<ReservationAdditionDto> ReservationAdditions { get; set; } = new List<ReservationAdditionDto>();

        public double Amount { get; set; }

        public string Status { get; set; }

        public DateTime PaymentDate { get; set; }

    }


}




