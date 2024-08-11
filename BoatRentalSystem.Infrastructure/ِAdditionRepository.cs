namespace BoatRentalSystem.Infrastructure
{
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;
    using BoatRentalSystem.Infrastructure.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdditionRepository : BaseRepository<Addition>, IAdditionRepository
    {
        private readonly ApplicationDbContext _context;
        public AdditionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
