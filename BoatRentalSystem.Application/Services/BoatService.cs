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
    public class BoatService
    {
        private readonly IBoatRepository _boatRepository;

        public BoatService(IBoatRepository boatRepository)
        {
            _boatRepository = boatRepository;
        }
        public Task<IEnumerable<Boat>> GetAllBoats()
        {
            return _boatRepository.GetAllAsync();
        }
        public Task<Boat> GetBoatById(int id)
        {
            return _boatRepository.GetByIdAsync(id);

        }
        public Task AddBoat(Boat Boat)
        {
            return _boatRepository.AddAsync(Boat);
        }

        public Task UpdateBoat(Boat Boat)
        {
            return _boatRepository.UpdateAsync(Boat.BoatId, Boat);
        }

        public Task DeleteBoat(int id)
        {
            return _boatRepository.DeleteAsync(id);
        }

    }
}
