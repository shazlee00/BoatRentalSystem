namespace BoatRentalSystem.Infrastructure.Repositories
{
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;
    using BoatRentalSystem.Infrastructure.Configurations;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        private readonly ApplicationDbContext _context;

        public PackageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
