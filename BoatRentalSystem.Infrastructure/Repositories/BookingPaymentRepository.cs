using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Infrastructure.Repositories
{
    public class BookingPaymentRepository:BaseRepository<BookingPayment>,IBookingPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingPaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
