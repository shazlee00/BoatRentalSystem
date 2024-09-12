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
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository ;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository ;
        }

        public Task<IEnumerable<Reservation>> GetAllReservations()
        {
            //return _reservationRepository.GetAllAsync();

            return _reservationRepository.GetAllReservationAsync();
        }
        public Task<Reservation> GetReservationById(int id)
        {
            return _reservationRepository.GetReservationByIdAsync(id);

        }
        public Task AddReservation(Reservation reservation)
        {
            return _reservationRepository.AddAsync(reservation);
        }

        public Task UpdateReservation(Reservation reservation)
        {
            return _reservationRepository.UpdateAsync(reservation.ReservationId, reservation);
        }

        public Task DeleteReservation(int id)
        {
            return _reservationRepository.DeleteAsync(id);
        }

    }
}
