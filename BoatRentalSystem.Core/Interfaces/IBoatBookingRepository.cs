using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Interfaces
{
    public interface IBoatBookingRepository:IBaseRepository<BoatBooking>
    {
        public  Task<IEnumerable<BoatBooking>> GetAllBoatBookingsAsync();


        public  Task<BoatBooking> GetBoatBookingByIdAsync(int id);
     
    }
}
