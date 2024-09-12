using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using BoatRentalSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Services
{
    using BoatRentalSystem.Core.Entities;
    public class BoatBookingService
    {
        private readonly IBoatBookingRepository _boatBookingRepository;

        public BoatBookingService(IBoatBookingRepository boatBookingRepository)
        {
            _boatBookingRepository = boatBookingRepository;
        }
        public Task<IEnumerable<BoatBooking>> GetAllBoatBookings()
        {
            return _boatBookingRepository.GetAllAsync();
        }
        public Task<BoatBooking> GetBoatBookingById(int id)
        {
            return _boatBookingRepository.GetByIdAsync(id);

        }
        public Task AddBoatBooking(BoatBooking boatBooking)
        {
            return _boatBookingRepository.AddAsync(boatBooking);
        }

        public Task UpdateBoatBooking(BoatBooking boatBooking)
        {
            return _boatBookingRepository.UpdateAsync(boatBooking.BoatId, boatBooking);
        }

        public Task DeleteBoatBooking(int id)
        {
            return _boatBookingRepository.DeleteAsync(id);
        }
    }
}
