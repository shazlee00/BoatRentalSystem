using BoatRentalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.BoatBooking.ViewModels
{
    public class BoatBookingDto
    {
        public int BoatBookingId { get; set; }

        public int CustomerId { get; set; }


        public int BoatId { get; set; }



        public DateTime BookingDate { get; set; }
        public int DurationHours { get; set; }


        public double TotalPrice { get; set; }

        public string Status { get; set; }
        public DateTime? CanceledAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }





        public List<BookingAdditionDto> BookingAdditions { get; set; }

    }


    public class AddBoatBookingDto
    {
        public int CustomerId { get; set; }


        public int BoatId { get; set; }

        public DateTime BookingDate { get; set; }
        public int DurationHours { get; set; }
      
    
        public List<AddBookingAdditionDto> BookingAdditions { get; set; }


    }

    public class UpdateBoatBookingDto
    {
        public int BoatBookingId { get; set; }

        public int CustomerId { get; set; }


        public int BoatId { get; set; }



        public DateTime BookingDate { get; set; }
        public int DurationHours { get; set; }


        public double TotalPrice { get; set; }

        public string Status { get; set; }
        public DateTime? CanceledAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        public List<BookingAdditionDto> BookingAdditions { get; set; }

    }







    public class  BookingAdditionDto
    {
        public int BookingAdditionId { get; set; }


        public int BoatBookingId { get; set; }

       

        public int AdditionId { get; set; }
   
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; } 

    }

    public class AddBookingAdditionDto
    {  
        public int AdditionId { get; set; }

        public int Quantity { get; set; }
  

    }

    public class UpdateBookingAdditionDto
    {
        public int BookingAdditionId { get; set; }

        public int AdditionId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }











}