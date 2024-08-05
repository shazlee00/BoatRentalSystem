﻿namespace BoatRentalSystem.Infrastructure
{
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdditionRepository : IAdditionRepository
    {
        private readonly List<Addition> _addition = new List<Addition>();
        public AdditionRepository()
        {
            _addition = new List<Addition>
            { 
                new Addition { Id = 1, Name = "Test1" },
                new Addition { Id = 2, Name = "Test2" },
                new Addition { Id = 3, Name = "Test3" },
            };
        }
        public async Task AddAddition(Addition addition)
        {
            addition.Id = _addition.Any() ? _addition.Max(c => c.Id) + 1 : 1;
            _addition.Add(addition);
            await Task.CompletedTask;
        }

        public async Task DeleteAddition(int id)
        {
            var Addition = _addition.FirstOrDefault(c => c.Id == id);
            if (Addition != null)
                _addition.Remove(Addition);

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Addition>> GetAllAdditions()
        {
            return await Task.FromResult(_addition);
        }


        public async Task<Addition> GetAdditionById(int id)
        {
            var Addition = _addition.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(Addition);
        }

        public async Task UpdateAddition(Addition addition)
        {
            var existingAddition = _addition.FirstOrDefault(x => x.Id == addition.Id);
            if (existingAddition != null)
            {
                existingAddition.Name = addition.Name;
            }
            await Task.CompletedTask;
        }
    }
}
