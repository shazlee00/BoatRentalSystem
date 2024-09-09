using BoatRentalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Boat.ViewModels
{
    public class BoatDto
    {
        public int BoatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Capacity { get; set; }

        public double ReservationPrice { get; set; }

        public string BoatStatus { get; set; }


        public int OwnerId { get; set; }

    }

    public class AddBoatDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Capacity { get; set; }

        public double ReservationPrice { get; set; }

        public int OwnerId { get; set; }
    }
    public class UpdateBoatDto
    {
        public int BoatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Capacity { get; set; }

        public double ReservationPrice { get; set; }

        public int OwnerId { get; set; }

        


    }

}
