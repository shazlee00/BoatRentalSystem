﻿namespace BoatRentalSystem.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
            Task<IEnumerable<TEntity>> GetAllAsync();
            Task<TEntity> GetByIdAsync(int id);
            Task AddAsync(TEntity entity);
            Task UpdateAsync(int id, TEntity entity);
            Task DeleteAsync(int id);
        
    }
}