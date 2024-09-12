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
    public class ReservationRepository: BaseRepository<Reservation>,IReservationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReservationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationAsync()
        {
            var result = await _dbContext.Reservations.Include(e => e.Boat).Include(e => e.Trip).Include(e=>e.ReservationAdditions).ThenInclude(e=>e.Addition).ToListAsync();
            return result;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            var reservations = await _dbContext.Reservations.Include(e => e.Boat).Include(e => e.Trip).Include(e => e.ReservationAdditions).ThenInclude(e => e.Addition).FirstOrDefaultAsync(e => e.ReservationId == id);

            return reservations;
        }
    }   

}
