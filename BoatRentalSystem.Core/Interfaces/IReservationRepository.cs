using BoatRentalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Interfaces
{
    public interface IReservationRepository: IBaseRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetAllReservationAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
    } 
}
