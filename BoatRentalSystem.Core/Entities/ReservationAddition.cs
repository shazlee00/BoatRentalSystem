using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoatRentalSystem.Core.Entities
{
    public class ReservationAddition
    {
        [Key]
       public int ReservationAdditionId { get; set; }

        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }


        public int AdditionId { get; set; }
        public Addition Addition { get; set; }  

        public int Quantity { get; set; } 
        public double TotalPrice { get { return Quantity * (Addition?.Price ?? 0); } }



       
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}