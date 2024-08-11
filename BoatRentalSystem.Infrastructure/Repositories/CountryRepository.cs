namespace BoatRentalSystem.Infrastructure.Repositories
{
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CountryRepository :BaseRepository<Country>, ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
