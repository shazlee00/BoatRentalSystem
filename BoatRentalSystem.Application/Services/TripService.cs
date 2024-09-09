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
    using BoatRentalSystem.Core.Entities;



    public class TripService
    {
        private readonly ITripRepository _tripRepository;
        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public Task<IEnumerable<Trip>> GetAllTrips()
        {
            return _tripRepository.GetAllAsync();
        }
        public Task<Trip> GetTripById(int id)
        {
            return _tripRepository.GetByIdAsync(id);

        }
        public Task AddTrip(Trip trip)
        {
            return _tripRepository.AddAsync(trip);
        }

        public Task UpdateTrip(Trip trip)
        {
            return _tripRepository.UpdateAsync(trip.TripId, trip);
        }

        public Task DeleteTrip(int id)
        {
            return _tripRepository.DeleteAsync(id);
        }
    }
}
