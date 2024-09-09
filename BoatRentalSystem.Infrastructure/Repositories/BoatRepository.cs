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
    public class BoatRepository : BaseRepository<Boat>, IBoatRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BoatRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Boat>> GetAvailbeAsync()
        {
            var availbeBoats= await _dbContext.Boats.Where(e => e.Status == BoatStatus.Approved).ToListAsync();

            return availbeBoats;
        }
    }
}
