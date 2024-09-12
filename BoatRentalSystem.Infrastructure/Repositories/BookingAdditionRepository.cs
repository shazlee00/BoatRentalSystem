using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Infrastructure.Repositories
{
    public class BookingAdditionRepository:BaseRepository<BookingAddition>, IBookingAdditionRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingAdditionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
