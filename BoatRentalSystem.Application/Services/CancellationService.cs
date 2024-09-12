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
    public class CancellationService
    {
        private readonly ICancellationRepository _cancellationRepository;

        public CancellationService(ICancellationRepository cancellationRepository)
        {
            _cancellationRepository = cancellationRepository;
        }



        public Task<IEnumerable<Cancellation>> GetAllCancellations()
        {
            return _cancellationRepository.GetAllAsync();
        }
        public Task<Cancellation> GetCancellationById(int id)
        {
            return _cancellationRepository.GetByIdAsync(id);

        }
        public Task AddCancellation(Cancellation cancellation)
        {
            return _cancellationRepository.AddAsync(cancellation);
        }

        public Task UpdateCancellation(Cancellation cancellation)
        {
            return _cancellationRepository.UpdateAsync(cancellation.CancellationId, cancellation);
        }

        public Task DeleteCancellation(int id)
        {
            return _cancellationRepository.DeleteAsync(id);
        }

    }
}
