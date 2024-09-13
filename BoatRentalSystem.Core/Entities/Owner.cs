using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string UserId { get; set; } //id for asp.net users

        public string? BusinessName { get; set; }

        public string? Address { get; set; }

        public double WalletBalance { get; set; } = 0.0;

        public DateTime CreatedAt { get; set; }= DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsVerified { get; set; }



        public List<Boat> Boats { get; set; }= new List<Boat>();
        public List<Trip> Trips { get; set; } = new List<Trip>();
        
        public List<Addition> Additions { get; set; } = new List<Addition>();

    }
}
