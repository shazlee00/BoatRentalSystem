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
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OwnerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Owner> GetByUserIdAsync(string userId)
        {
            return await _dbContext.Owners.FirstOrDefaultAsync(e => e.UserId == userId);
        }

        public async Task<int> GetIdByUserIDAsync(string userId)
        {
            var user = await _dbContext.Owners.FirstOrDefaultAsync(e => e.UserId == userId);

            return user.Id;
        }


    }
}
