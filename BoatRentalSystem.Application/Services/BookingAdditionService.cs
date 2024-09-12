using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using BoatRentalSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Services
{
    public class BookingAdditionService
    {
        private readonly IBookingAdditionRepository _bookingAdditionRepository;
        public BookingAdditionService(IBookingAdditionRepository bookingAdditionRepository)
        {
            _bookingAdditionRepository = bookingAdditionRepository;
        }

        public Task<IEnumerable<BookingAddition>> GetAllBookingAdditions()
        {
            return _bookingAdditionRepository.GetAllAsync();
        }
        public Task<BookingAddition> GetBookingAdditionById(int id)
        {
            return _bookingAdditionRepository.GetByIdAsync(id);

        }
        public Task AddBookingAddition(BookingAddition bookingAddition)
        {
            return _bookingAdditionRepository.AddAsync(bookingAddition);
        }

        public Task UpdateBookingAddition(BookingAddition bookingAddition)
        {
            return _bookingAdditionRepository.UpdateAsync(bookingAddition.BookingAdditionId, bookingAddition);
        }

        public Task DeleteBookingAddition(int id)
        {
            return _bookingAdditionRepository.DeleteAsync(id);
        }






    }
}
