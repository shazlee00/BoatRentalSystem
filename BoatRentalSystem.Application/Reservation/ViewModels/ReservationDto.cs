using BoatRentalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Reservation.ViewModels
{


    public class ReservationDto
    {

        public int ReservationId { get; set; }


        public int CustomerId { get; set; }
    


        public int TripId { get; set; }
 

        [ForeignKey("BoatId")]
        public int BoatId { get; set; }

        public int NumberOfPeople { get; set; }
        public double TotalPrice { get; set; }

        public DateTime ReservationDate { get; set; }


        public string Status { get; set; }


        public DateTime? CanceledAt { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public DateTime? UpdatedAt { get; set; }

        public List<ReservationAdditionDto> ReservationAdditions { get; set; } = new List<ReservationAdditionDto>();
    }



    public class AddReservationDto
    {
        public int CustomerId { get; set; }
        public int TripId { get; set; }
        public int BoatId { get; set; }

        public int NumberOfPeople { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<AddReservationAdditionDto> ReservationAdditions { get; set; } = new List<AddReservationAdditionDto>();



    }
    public class ReservationAdditionDto
    {
        public int ReservationAdditionId { get; set; }

    
        public int ReservationId { get; set; }
      


        public int AdditionId { get; set; }
      

        public int Quantity { get; set; }
        public double TotalPrice { get; set; }




        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }

    public class AddReservationAdditionDto
    {
        public int AdditionId { get; set; }
        public int Quantity { get; set; }
    }
    public class UpdateReservationAdditionDto
    {
        public int ReservationAdditionId { get; set; }
        public int AdditionId { get; set; }
        public int Quantity { get; set; }
    }



    public class UpdateReservationDto
    {

        public int ReservationId { get; set; }


        public int NumberOfPeople { get; set; }
        public double TotalPrice { get; set; }

    
        public DateTime CreatedAt { get; set; } = DateTime.Now;


       

        public List<UpdateReservationAdditionDto> ReservationAdditions { get; set; } = new List<UpdateReservationAdditionDto>();
    }




}
