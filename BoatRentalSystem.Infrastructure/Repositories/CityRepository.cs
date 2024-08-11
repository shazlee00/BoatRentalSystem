namespace BoatRentalSystem.Infrastructure.Repositories
{
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CityRepository :BaseRepository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
