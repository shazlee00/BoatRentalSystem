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
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        public Task<Customer> GetByUserIdAsync(string userId)
        {
            return _context.Customers.FirstOrDefaultAsync(e => e.UserId == userId);
        }
    }
}
