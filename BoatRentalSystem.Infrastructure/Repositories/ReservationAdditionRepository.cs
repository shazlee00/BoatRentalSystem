using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;

namespace BoatRentalSystem.Infrastructure.Repositories
{
    public class ReservationAdditionRepository: BaseRepository<ReservationAddition>,IReservationAdditionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReservationAdditionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
