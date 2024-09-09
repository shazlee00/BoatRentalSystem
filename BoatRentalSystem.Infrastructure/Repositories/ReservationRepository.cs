using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
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
        }
    }
}
