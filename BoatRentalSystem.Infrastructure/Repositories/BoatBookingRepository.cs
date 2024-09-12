using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Infrastructure.Repositories
{
    public class BoatBookingRepository : BaseRepository<BoatBooking>, IBoatBookingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BoatBookingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<BoatBooking>> GetAllBoatBookingsAsync()
        {
            var result = await _dbContext.BoatBookings.Include(e => e.Boat).Include(e => e.BookingAdditions).ThenInclude(e => e.Addition).ToListAsync();
            return result;
        }

        public async Task<BoatBooking> GetBoatBookingByIdAsync(int id)
        {
            var reservations = await _dbContext.BoatBookings.Include(e => e.Boat).Include(e => e.BookingAdditions).ThenInclude(e => e.Addition).FirstOrDefaultAsync(e => e.BoatBookingId == id);

            return reservations;
        }




    }
}
