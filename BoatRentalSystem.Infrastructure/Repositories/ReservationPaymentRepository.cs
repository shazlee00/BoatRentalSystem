using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Infrastructure.Repositories
{
    public class ReservationPaymentRepository :BaseRepository<ReservationPayment>, IReservationPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReservationPaymentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
