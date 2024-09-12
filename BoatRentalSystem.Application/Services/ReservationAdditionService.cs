using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;

namespace BoatRentalSystem.Application.Services
{
    public class ReservationAdditionService
    {
        private readonly IReservationAdditionRepository _reservationAdditionRepository ;

        public ReservationAdditionService(IReservationAdditionRepository reservationAdditionRepository)
        {
            _reservationAdditionRepository = reservationAdditionRepository ;
        }

        public Task<IEnumerable<ReservationAddition>> GetAllReservationAdditions()
        {
            return _reservationAdditionRepository.GetAllAsync();
        }
        public Task<ReservationAddition> GetReservationAdditionById(int id)
        {
            return _reservationAdditionRepository.GetByIdAsync(id);

        }
        public Task AddReservationAddition(ReservationAddition reservationAddition)
        {
            return _reservationAdditionRepository.AddAsync(reservationAddition);
        }

        public Task UpdateReservationAddition(ReservationAddition reservationAddition)
        {
            return _reservationAdditionRepository.UpdateAsync(reservationAddition.ReservationId, reservationAddition);
        }

        public Task DeleteReservationAddition(int id)
        {
            return _reservationAdditionRepository.DeleteAsync(id);
        }

    }
}
