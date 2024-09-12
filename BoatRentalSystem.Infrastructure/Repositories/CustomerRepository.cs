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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public Task<Customer> GetByUserIdAsync(string userId)
        {
            return _dbContext.Customers.FirstOrDefaultAsync(e => e.UserId == userId);
        }

        public async Task<int> GetIdByUserIDAsync(string userId)
        {
            var user = await _dbContext.Customers.FirstOrDefaultAsync(e => e.UserId == userId);

            return user.Id;
        }
    }
}
