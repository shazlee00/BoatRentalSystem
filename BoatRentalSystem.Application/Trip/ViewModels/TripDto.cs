using BoatRentalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Trip.ViewModels
{
    public class TripDto
    {
        public int TripId { get; set; }
        public int OwnerId { get; set; }
        public int BoatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PricePerPerson { get; set; }
        public int MaxPeople { get; set; }

        public DateTime CancellationDeadline { get; set; }

        public TripStatus Status { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

    }


    public class AddTripDto
    {
        public int OwnerId { get; set; }
        public int BoatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PricePerPerson { get; set; }
        public int MaxPeople { get; set; }

        public DateTime CancellationDeadline { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }


    public class UpdateTripDto
    {
        public int TripId { get; set; }
        public int OwnerId { get; set; }
        public int BoatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PricePerPerson { get; set; }
        public int MaxPeople { get; set; }

        public TripStatus Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime CancellationDeadline { get; set; }

    }





}
